using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using PokeApp.DAL;
using PokeApp.Models;
using PokeApp.ViewModels;


namespace PokeApp.Views
{
    public partial class ShopView : UserControl
    {
        private MediaPlayer _mediaPlayer = new MediaPlayer();
        private List<Item>? items;
        private DAL.DAL dAL = new DAL.DAL();

        public ShopView()
        {
            InitializeComponent();
            this.IsVisibleChanged += ShopView_IsVisibleChanged;
        }

        private void ShopView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible)
            {
                StartEntranceAnimation();
            }
        }

        private void LoadImages()
        {
            Grid grid = new Grid();
            items = dAL.ItemFactory.GetAll();
            int totalImages = items.Count;

            for (int i = 0; i < 3; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < 5; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            int rowIndex = 0, colIndex = 0, index = 0;
            int tag = 1;
            foreach (Item item in items)
            {
                Image img = new Image
                {
                    Source = new BitmapImage(new Uri(item.Sprite, UriKind.Absolute)),
                    Width = 50,
                    Height = 50,
                    Tag = tag++,
                    Cursor = Cursors.Hand,
                    Margin = new Thickness(2)
                };

                img.MouseDown += (s, e) => Click(s, e, item);

                Grid.SetRow(img, rowIndex);
                Grid.SetColumn(img, colIndex);

                grid.Children.Add(img);

                if (index == 0 || index == 1)
                {
                    index++;
                    colIndex++;
                }
                else
                {
                    index = 0;
                    colIndex = 0;
                    rowIndex++;
                }
            }

            UI.Children.Add(grid);
        }

        private void Click(object sender, MouseButtonEventArgs e, Item item)
        {
            dAL.InventoryFactory.AddToItemInventory(item);
        }

        private void StartEntranceAnimation()
        {
            Canvas.SetTop(CharacterSprite, 690);
            Canvas.SetLeft(CharacterSprite, 550);
            CharacterSprite.Source = new BitmapImage(new Uri("pack://application:,,,/Views/Media/Images/characterBack.png"));

            DoubleAnimation moveUp = new()
            {
                From = 690,
                To = 250,
                Duration = TimeSpan.FromSeconds(2),
                FillBehavior = FillBehavior.HoldEnd
            };

            Storyboard storyboardUp = new();
            storyboardUp.Children.Add(moveUp);
            Storyboard.SetTarget(moveUp, CharacterSprite);
            Storyboard.SetTargetProperty(moveUp, new PropertyPath("(Canvas.Top)"));

            storyboardUp.Completed += (s, args) =>
            {
                CharacterSprite.Source = new BitmapImage(new Uri("pack://application:,,,/Views/Media/Images/characterProfil.png"));

                DoubleAnimation moveLeft = new()
                {
                    From = 550,
                    To = 500,
                    Duration = TimeSpan.FromSeconds(2),
                    FillBehavior = FillBehavior.HoldEnd
                };

                Storyboard storyboardLeft = new();
                storyboardLeft.Children.Add(moveLeft);
                Storyboard.SetTarget(moveLeft, CharacterSprite);
                Storyboard.SetTargetProperty(moveLeft, new PropertyPath("(Canvas.Left)"));

                storyboardLeft.Completed += (ss, ee) => LoadShopInterface();
                storyboardLeft.Begin();
            };

            storyboardUp.Begin();
        }

        private void LoadShopInterface()
        {
            AnimationCanvas.Visibility = Visibility.Visible;
            ShopPanel.Visibility = Visibility.Visible;
            LoadImages();
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            // Hide this view and stop music if needed
            this.Visibility = Visibility.Hidden;

            // Optional: stop animations or media
            // _mediaPlayer.Stop();

            // Show main menu again (find parent window)
            if (Window.GetWindow(this) is MainMenu mainWindow)
            {
                mainWindow.TitleVideo.Visibility = Visibility.Visible;
                mainWindow.MartAudio.Stop();
                mainWindow.TitleVideo.Play();
                mainWindow.TitleAudio.Play();
                _mediaPlayer.Stop();

                // Reset visibility of buttons
                mainWindow.Button1.Visibility = Visibility.Visible;
                mainWindow.Button1Image.Visibility = Visibility.Visible;
                mainWindow.Button1Label.Visibility = Visibility.Visible;
                mainWindow.TitleImage.Visibility = Visibility.Visible;
                mainWindow.Button2.Visibility = Visibility.Visible;
                mainWindow.Button2Image.Visibility = Visibility.Visible;
                mainWindow.Button2Label.Visibility = Visibility.Visible;
                mainWindow.Button3.Visibility = Visibility.Visible;
                mainWindow.Button3Image.Visibility = Visibility.Visible;
                mainWindow.Button3Label.Visibility = Visibility.Visible;
                mainWindow.Button4.Visibility = Visibility.Visible;
                mainWindow.Button4Image.Visibility = Visibility.Visible;
                mainWindow.Button4Label.Visibility = Visibility.Visible;
            }
        }
    }
}

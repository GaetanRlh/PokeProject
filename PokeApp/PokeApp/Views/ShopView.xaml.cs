using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using PokeApp.ViewModels;
using static PokeApp.ViewModels.ShopVM;

namespace PokeApp.Views
{
    public partial class ShopView : UserControl
    {
        private MediaPlayer _mediaPlayer = new MediaPlayer();
        private readonly ShopVM _viewModel = new();
        private bool _hasAnimated = false;

        public ShopView()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
            this.IsVisibleChanged += ShopView_IsVisibleChanged;
        }

        private void ShopView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible && !_hasAnimated)
            {
                _hasAnimated = true;
                StartEntranceAnimation();
            }
        }

        private void StartEntranceAnimation()
        {
            Canvas.SetTop(CharacterSprite, 690);
            Canvas.SetLeft(CharacterSprite, 350);
            CharacterSprite.Source = new BitmapImage(new Uri("pack://application:,,,/Views/Media/Images/characterBack.png"));

            DoubleAnimation moveUp = new()
            {
                From = 690,
                To = 180,
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
                    From = 350,
                    To = 290,
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
            _viewModel.LoadInventory();
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

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

        public ShopView()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
            this.Loaded += ShopView_Loaded;
        }

        private async void ShopView_Loaded(object sender, RoutedEventArgs e)
        {
            CharacterSprite.Source = new BitmapImage(new Uri("pack://application:,,,/Views/Media/Images/characterBack.png"));

            DoubleAnimation moveForward = new()
            {
                From = 410,
                To = 106,
                Duration = TimeSpan.FromSeconds(2)
            };
            Storyboard.SetTarget(moveForward, CharacterSprite);
            Storyboard.SetTargetProperty(moveForward, new PropertyPath("(Canvas.Top)"));

            Storyboard storyboard1 = new();
            storyboard1.Children.Add(moveForward);
            storyboard1.Begin();

            await Task.Delay(2000);

            CharacterSprite.Source = new BitmapImage(new Uri("pack://application:,,,/Views/Media/Images/characterProfil.png"));

            DoubleAnimation moveLeft = new()
            {
                From = 260,
                To = 215,
                Duration = TimeSpan.FromSeconds(2)
            };
            Storyboard.SetTarget(moveLeft, CharacterSprite);
            Storyboard.SetTargetProperty(moveLeft, new PropertyPath("(Canvas.Left)"));

            Storyboard storyboard2 = new();
            storyboard2.Children.Add(moveLeft);
            storyboard2.Begin();

            await Task.Delay(2000);

            LoadShopInterface();
        }

        private void LoadShopInterface()
        {
            AnimationCanvas.Visibility = Visibility.Visible;
            ShopPanel.Visibility = Visibility.Visible;
            _viewModel.LoadInventory();
        }
    }
}

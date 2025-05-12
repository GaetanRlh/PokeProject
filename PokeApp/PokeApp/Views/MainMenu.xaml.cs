using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PokeApp.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            BackgroundVideo.Play();
            BackgroundAudio.Play();
        }

        private void BackgroundVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            BackgroundVideo.Position = System.TimeSpan.Zero;
            BackgroundVideo.Play();
            BackgroundAudio.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BackgroundVideo.Stop();
            BackgroundAudio.Stop();
            BackgroundVideo.Visibility = Visibility.Hidden;
            TitleAudio.Play();
            Button1.Visibility = Visibility.Visible;
            Button1Image.Visibility = Visibility.Visible;
            Button1Label.Visibility = Visibility.Visible;
            TitleImage.Visibility = Visibility.Visible;
        }

        private void TitleAudio_MediaEnded(object sender, RoutedEventArgs e)
        {
            TitleAudio.Play();
        }
    }
}

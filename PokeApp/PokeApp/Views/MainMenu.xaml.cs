using PokeApp.Models;
using PokeApp.ViewModels;
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
            BackgroundVideo.Stop();
            BackgroundVideo.Play();
            BackgroundAudio.Stop();
            BackgroundAudio.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BackgroundVideo.Stop();
            BackgroundAudio.Stop();
            BackgroundVideo.Visibility = Visibility.Hidden;
            TitleAudio.Play();
            TitleVideo.Play();
            Button1.Visibility = Visibility.Visible;
            Button1Image.Visibility = Visibility.Visible;
            Button1Label.Visibility = Visibility.Visible;
            TitleImage.Visibility = Visibility.Visible;
            Button2Image.Visibility = Visibility.Visible;
            Button2Label.Visibility = Visibility.Visible;
            Button2.Visibility = Visibility.Visible;
            Button3Image.Visibility = Visibility.Visible;
            Button3Label.Visibility = Visibility.Visible;
            Button3.Visibility = Visibility.Visible;
            Button4Image.Visibility = Visibility.Visible;
            Button4Label.Visibility = Visibility.Visible;
            Button4.Visibility = Visibility.Visible;
            MainButton.Visibility = Visibility.Hidden;
        }

        private void BattleVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            BattleVideo.Visibility = Visibility.Hidden;
            BattleVideo.Stop();
            CatchUserControl.Visibility = Visibility.Visible;
            CatchUserControl.GeneratePokemon();
        }

        private void BattleAudio_MediaEnded(object sender, RoutedEventArgs e)
        {
            BattleAudio.Stop();
            BattleAudio.Play();
        }

        private void TitleAudio_MediaEnded(object sender, RoutedEventArgs e)
        {
            TitleAudio.Stop();
            TitleAudio.Play();
        }

        private void Title_MediaEnded(object sender, RoutedEventArgs e)
        {
            TitleVideo.Stop();
            TitleVideo.Play();
        }

        private async void Catch_Click(object sender, RoutedEventArgs e)
        {
            BattleVideo.Visibility = Visibility.Visible;
            CatchUserControl.Construct(this);
            TitleVideo.Stop();
            TitleVideo.Visibility = Visibility.Hidden;
            TitleAudio.Stop();
            Button1.Visibility = Visibility.Hidden;
            Button1Image.Visibility = Visibility.Hidden;
            Button1Label.Visibility = Visibility.Hidden;
            TitleImage.Visibility = Visibility.Hidden;
            Button2Image.Visibility = Visibility.Hidden;
            Button2Label.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button3Image.Visibility = Visibility.Hidden;
            Button3Label.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;
            Button4Image.Visibility = Visibility.Hidden;
            Button4Label.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;
            BattleVideo.Play();
            BattleAudio.Play();
            CatchUserControl.catchVM.StartEncounter();
            await Task.Delay(4275);
            PokemonName.Content = CatchUserControl.catchVM.CurrentPokemon!.Name.ToUpper();
            await Task.Delay(800);
            PokemonName.Content = "";
        }

        public void CatchOver()
        {
            BattleAudio.Stop();
            TitleAudio.Play();
            TitleVideo.Visibility = Visibility.Visible;
            TitleVideo.Play();
            Button1.Visibility = Visibility.Visible;
            Button1Image.Visibility = Visibility.Visible;
            Button1Label.Visibility = Visibility.Visible;
            TitleImage.Visibility = Visibility.Visible;
            Button2Image.Visibility = Visibility.Visible;
            Button2Label.Visibility = Visibility.Visible;
            Button2.Visibility = Visibility.Visible;
            Button3Image.Visibility = Visibility.Visible;
            Button3Label.Visibility = Visibility.Visible;
            Button3.Visibility = Visibility.Visible;
            Button4Image.Visibility = Visibility.Visible;
            Button4Label.Visibility = Visibility.Visible;
            Button4.Visibility = Visibility.Visible;
            MainButton.Visibility = Visibility.Hidden;
        }

        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            TitleVideo.Stop();
            TitleVideo.Visibility = Visibility.Hidden;
            TitleAudio.Stop();
            Button1.Visibility = Visibility.Hidden;
            Button1Image.Visibility = Visibility.Hidden;
            Button1Label.Visibility = Visibility.Hidden;
            TitleImage.Visibility = Visibility.Hidden;
            Button2Image.Visibility = Visibility.Hidden;
            Button2Label.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button3Image.Visibility = Visibility.Hidden;
            Button3Label.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;
            Button4Image.Visibility = Visibility.Hidden;
            Button4Label.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;
            ShopUserControl.Visibility = Visibility.Visible;
            MartAudio.Play();
        }


        private void MartAudio_MediaEnded(object sender, RoutedEventArgs e)
        {
            MartAudio.Pause();
            MartAudio.Play();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            TitleVideo.Stop();
            TitleVideo.Visibility = Visibility.Hidden;
            Button1.Visibility = Visibility.Hidden;
            Button1Image.Visibility = Visibility.Hidden;
            Button1Label.Visibility = Visibility.Hidden;
            TitleImage.Visibility = Visibility.Hidden;
            Button2Image.Visibility = Visibility.Hidden;
            Button2Label.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button3Image.Visibility = Visibility.Hidden;
            Button3Label.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;
            Button4Image.Visibility = Visibility.Hidden;
            Button4Label.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;
            BoxUserControl.Construct(this);
            BoxUserControl.Visibility = Visibility.Visible;
            BoxUserControl.LoadImages();
        }

        public void BoxExit()
        {
            BoxUserControl.Visibility = Visibility.Hidden;
            TitleVideo.Visibility = Visibility.Visible;
            TitleVideo.Play();
            Button1.Visibility = Visibility.Visible;
            Button1Image.Visibility = Visibility.Visible;
            Button1Label.Visibility = Visibility.Visible;
            TitleImage.Visibility = Visibility.Visible;
            Button2Image.Visibility = Visibility.Visible;
            Button2Label.Visibility = Visibility.Visible;
            Button2.Visibility = Visibility.Visible;
            Button3Image.Visibility = Visibility.Visible;
            Button3Label.Visibility = Visibility.Visible;
            Button3.Visibility = Visibility.Visible;
            Button4Image.Visibility = Visibility.Visible;
            Button4Label.Visibility = Visibility.Visible;
            Button4.Visibility = Visibility.Visible;
            MainButton.Visibility = Visibility.Hidden;
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0x1);
        }
    }
}

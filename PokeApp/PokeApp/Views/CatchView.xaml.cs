using PokeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibVLCSharp.Shared;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Policy;
using System.Net.Http;
using System.IO;
using PokeApp.Helper;

namespace PokeApp.Views
{
    /// <summary>
    /// Interaction logic for CatchView.xaml
    /// </summary>
    public partial class CatchView : UserControl
    {
        private CatchVM catchVM;
        private LibVLC _libVLC;
        private LibVLCSharp.Shared.MediaPlayer _mediaPlayer;
        private Media? _currentCry;

        public CatchView()
        {
            InitializeComponent();
            Core.Initialize();
            _libVLC = new LibVLC();
            _mediaPlayer = new LibVLCSharp.Shared.MediaPlayer(_libVLC);
            catchVM = new CatchVM();
        }

        public async void GeneratePokemon()
        {
            catchVM.StartEncounter();

            _currentCry?.Dispose();

            string cryPath = await CryManager.GetCachedCryAsync(
                catchVM.CurrentPokemon!.Cry,
                catchVM.CurrentPokemon.Name);

            _currentCry = new Media(_libVLC, new Uri(cryPath));

            try
            {
                await _currentCry.Parse(MediaParseOptions.ParseLocal);

                _mediaPlayer.Stop();
                _mediaPlayer.Play(_currentCry);

                Sprite.Source = new BitmapImage(new Uri(catchVM.CurrentPokemon.Sprite, UriKind.Absolute));
                PokemonName.Content = catchVM.CurrentPokemon.Name;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

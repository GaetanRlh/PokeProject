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
using System.Windows.Media.Animation;
using PokeApp.Models;
using PokeApp.DAL;

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
        private DAL.DAL dAL = new DAL.DAL();
        private ItemInventory inventory;
        private MainMenu? menu;

        public CatchView()
        {
            InitializeComponent();
            Core.Initialize();
            inventory = dAL.InventoryFactory.GetItemInventory();
            _libVLC = new LibVLC();
            _mediaPlayer = new LibVLCSharp.Shared.MediaPlayer(_libVLC);
            catchVM = new CatchVM();
        }

        public void Construct(MainMenu menu)
        {
            this.menu = menu;
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

        private void Item_Click(object sender, RoutedEventArgs e)
        {
            if(ItemBag.Visibility == Visibility.Visible)
            {
                ItemBag.Visibility = Visibility.Hidden;
                Items.Children.Clear();
            }
            else
            {
                ItemBag.Visibility = Visibility.Visible;
                LoadImages();
            }
        }

        private void LoadImages()
        {
            Grid grid = new Grid();
            inventory = dAL.InventoryFactory.GetItemInventory();
            int totalImages = inventory.Items.Count;

            for (int i = 0; i < 4; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < 5; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            int rowIndex = 0, colIndex = 0, index = 0;
            int tag = 1;
            foreach (Item item in inventory.Items)
            {
                Image img = new Image
                {
                    Source = new BitmapImage(new Uri(item.Sprite, UriKind.Absolute)),
                    Width = 50,
                    Height = 50,
                    Tag = tag++,
                    Cursor = Cursors.Hand,
                    Margin = new Thickness(5)
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

            Items.Children.Add(grid);
        }

        private void Click(object sender, MouseButtonEventArgs e, Item item)
        {
            bool isSuccess = catchVM.CatchPokemon(item);
            if (isSuccess)
            {
                this.Visibility = Visibility.Hidden;
                menu!.CatchOver();
            }
            else
            {
                Items.Children.Clear();
                LoadImages();
            }
        }

        private void Flee_Click(object sender, RoutedEventArgs e)
        {
            catchVM.Flee();
            this.Visibility = Visibility.Hidden;
            menu!.CatchOver();
        }
    }
}

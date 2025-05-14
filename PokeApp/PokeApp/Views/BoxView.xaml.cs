using PokeApp.DAL;
using PokeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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

namespace PokeApp.Views
{
    /// <summary>
    /// Interaction logic for BoxView.xaml
    /// </summary>
    public partial class BoxView : UserControl
    {
        private DAL.DAL dAL = new DAL.DAL();
        private MainMenu? menu;

        public BoxView()
        {
            InitializeComponent();
        }

        public void Construct(MainMenu menu)
        {
            this.menu = menu;
        }

        public void LoadImages()
        {
            Grid grid = new Grid();
            PokemonInventory inventory = dAL.InventoryFactory.GetPokemonInventory();
            int totalImages = inventory.Pokemons.Count;

            for (int i = 0; i < 3; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < 5; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            int rowIndex = 0, colIndex = 0, index = 0;
            int tag = 1;
            foreach (Pokemon pokemon in inventory.Pokemons)
            {
                Image img = new Image
                {
                    Source = new BitmapImage(new Uri(pokemon.Sprite, UriKind.Absolute)),
                    Width = 200,
                    Height = 200,
                    Tag = tag++,
                    Margin = new Thickness(5)
                };

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

            PokeBox.Children.Add(grid);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            menu!.BoxExit();
        }
    }
}

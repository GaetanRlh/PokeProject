using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokeApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp.ViewModels
{
    public partial class BoxVM : ObservableObject
    {
        public partial class BoxViewModel : ObservableObject
        {
            private readonly DAL.DAL _dal = new();

            [ObservableProperty]
            private ObservableCollection<Pokemon> _pokemons = new();

            public BoxViewModel()
            {
                LoadBox();
            }

            [RelayCommand]
            public void LoadBox()
            {
                Pokemons.Clear();
                var pokemons = _dal.InventoryFactory.GetPokemonInventory().Pokemons;
                foreach (var p in pokemons)
                    Pokemons.Add(p);
            }
        }
    }
}

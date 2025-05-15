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
    public partial class CatchVM : ObservableObject
    {
        private readonly DAL.DAL _dal = new();

        [ObservableProperty]
        private ObservableCollection<Item> _itemInventory = new();

        [ObservableProperty]
        private Pokemon? _currentPokemon;

        [ObservableProperty]
        private Item? _selectedPokeball;

        public Action? OnFleeRequested { get; set; }

        public CatchVM()
        {
            LoadInventory();
        }

        public void StartEncounter()
        {
            CurrentPokemon = _dal.PokemonFactory.GetRandom();
        }
        public bool CatchPokemon(Item pokeball)
        {
            bool success = false;
            if (CurrentPokemon == null) { return false; }

            success = SimulateCatch(pokeball.Name);
            UsePokeball(pokeball);

            if (success)
            {
                _dal.InventoryFactory.AddToPokemonInventory(CurrentPokemon);
                CurrentPokemon = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        [RelayCommand]
        public void Flee()
        {
            CurrentPokemon = null;
            OnFleeRequested?.Invoke();
        }

        private bool SimulateCatch(string pokeBallName)
        {
            Random rand = new();
            return pokeBallName switch
            {
                "Pokéball" => rand.NextDouble() < 0.25,
                "Greatball" => rand.NextDouble() < 0.5,
                "Masterball" => true,
                _ => false
            };
        }

        private void UsePokeball(Item item)
        {
            var match = ItemInventory.FirstOrDefault(i => i.Id == item.Id);
            if (match != null)
            {
                ItemInventory.Remove(match);
                _dal.InventoryFactory.DeleteFromItemInventory(item);
            }
        }

        public void LoadInventory()
        {
            ItemInventory.Clear();
            foreach (var item in _dal.InventoryFactory.GetItemInventory().Items)
                ItemInventory.Add(item);
        }
    }
}

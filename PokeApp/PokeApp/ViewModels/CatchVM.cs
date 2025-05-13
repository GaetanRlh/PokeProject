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

        [RelayCommand]
        public void CatchPokemon(Item pokeball)
        {
            bool success = false;
            if (CurrentPokemon == null || SelectedPokeball == null  ) { return; }

            do
            {
                UsePokeball(SelectedPokeball);
                success = SimulateCatch(SelectedPokeball.Name);

            } while (!success);

            _dal.InventoryFactory.AddToPokemonInventory(CurrentPokemon);
            CurrentPokemon = null;
            LoadInventory();
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
                "Pokeball" => rand.NextDouble() < 0.2,
                "Hyperball" => rand.NextDouble() < 0.4,
                "Ultraball" => rand.NextDouble() < 0.7,
                "Masterball" => true,
                _ => false
            };
        }

        private void UsePokeball(Item item)
        {
            var match = ItemInventory.FirstOrDefault(i => i.Id == item.Id);
            if (match != null)
                ItemInventory.Remove(match);
        }

        public void LoadInventory()
        {
            ItemInventory.Clear();
            foreach (var item in _dal.InventoryFactory.GetItemInventory().Items)
                ItemInventory.Add(item);
        }
    }
}

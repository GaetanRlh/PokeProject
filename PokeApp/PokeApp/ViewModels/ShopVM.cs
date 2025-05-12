using CommunityToolkit.Mvvm.Collections;
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
    public partial class ShopVM : ObservableObject
    {
        public partial class ShopViewModel : ObservableObject
        {
            private readonly DAL.DAL _dal = new();

            [ObservableProperty]
            private ObservableCollection<Item> _Inventory = new();

            public ShopViewModel()
            {
                LoadInventory();
            }

            [RelayCommand]
            public void BuyItem(Item item)
            {
                _dal.InventoryFactory.AddToItemInventory(item);
                LoadInventory();
            }

            public void LoadInventory()
            {
                Inventory.Clear();
                var items = _dal.InventoryFactory.GetItemInventory().Items;
                foreach (var item in items)
                    Inventory.Add(item);
            }
        }
    }
}

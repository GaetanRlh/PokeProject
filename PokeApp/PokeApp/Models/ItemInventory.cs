using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp.Models
{
    public class ItemInventory
    {
        public List<Item> Items = new List<Item>();

        public ItemInventory() { }
        public ItemInventory(List<Item> items)
        {
            Items = items;
        }
    }
}

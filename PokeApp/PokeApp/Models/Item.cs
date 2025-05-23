﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Sprite { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Item() { }
        public Item(int id, string name, string sprite, decimal price)
        {
            Id = id;
            Name = name;
            Sprite = sprite;
            Price = price;
        }
    }
}

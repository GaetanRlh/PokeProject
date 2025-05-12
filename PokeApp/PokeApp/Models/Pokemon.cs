using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PokeApp.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cry { get; set; } = string.Empty;
        public string Sprite { get; set; } = string.Empty;

        public Pokemon() { }
        public Pokemon(int id,string name, string cry, string sprite)
        {
            Id = id;
            Name = name;
            Cry = cry;
            Sprite = sprite;
        }
    }
}

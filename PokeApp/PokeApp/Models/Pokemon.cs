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
        public string Name { get; set; }
        public string Cry {  get; set; }
        public string Type { get; set; }
        public BitmapImage Sprite { get; set; }

        public Pokemon(int id,string name,string cry, string type, BitmapImage sprite)
        {
            Id = id;
            Name = name;
            Cry = cry;
            Type = type;
            Sprite = sprite;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp.Models
{
    public class PlayerInventory
    {
        public int Money { get; set; }
        public List<PokeBall>? PokeBalls { get; set; }
        public List<Pokemon> Pokemons { get; set; }



    }
}

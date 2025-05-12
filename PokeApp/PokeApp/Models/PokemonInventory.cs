using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp.Models
{
    public class PokemonInventory
    {
        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public PokemonInventory() { }
        public PokemonInventory(List<Pokemon> pokemon)
        {
            Pokemons = pokemon;
        }
    }
}

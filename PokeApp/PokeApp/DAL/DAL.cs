using PokeApp.DAL.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp.DAL
{
    public class DAL
    {
        private InventoryFactory? _inventoryFactory = null;
        private ItemFactory? _itemFactory = null;
        private PokemonFactory? _pokemonFactory = null;

        /*
         * NE PAS OUBLIER DE CHANGER CE CONNECTION STRING POUR QUE L'APPLICATION MARCHE. À FIN DE FAIRE DES TESTS, CETTE STRING EST PAR DEFAUT EN LOCAL HOST
         */
        public static string Connection
        {
            get
            {
                return "Server=sql.decinfo-cchic.ca;Port=33306;Database=h25_test_intro_api_2232508;Uid=dev-2232508;Pwd=Lucarinox123";
            }
        }

        public InventoryFactory InventoryFactory
        {
            get
            {
                if (_inventoryFactory is null) _inventoryFactory = new InventoryFactory(PokemonFactory, ItemFactory);
                return _inventoryFactory;
            }
        }

        public ItemFactory ItemFactory
        {
            get
            {
                if (_itemFactory is null) _itemFactory = new ItemFactory();
                return _itemFactory;
            }
        }

        public PokemonFactory PokemonFactory
        {
            get
            {
                if(_pokemonFactory is null) _pokemonFactory= new PokemonFactory();
                return _pokemonFactory;
            }
        }
    }
}

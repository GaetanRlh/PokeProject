using MySql.Data.MySqlClient;
using PokeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp.DAL.Factories
{
    public class InventoryFactory
    {
        private PokemonFactory _pokemonFactory;
        private ItemFactory _itemFactory;

        public InventoryFactory(PokemonFactory pokemonFactory, ItemFactory itemFactory)
        { 
            _pokemonFactory = pokemonFactory;
            _itemFactory = itemFactory;
        }

        public PokemonInventory GetPokemonInventory()
        {
            List<Pokemon> pokemon = new List<Pokemon>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.Connection);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tbl_inventairepokemon";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    pokemon.Add(_pokemonFactory.CreateFromReader(mySqlDataReader));
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return new PokemonInventory(pokemon.ToList());
        }

        public ItemInventory GetItemInventory()
        {
            List<Item> items = new List<Item>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.Connection);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tbl_inventaireitem";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    items.Add(_itemFactory.CreateFromReader(mySqlDataReader));
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return new ItemInventory(items.ToList());
        }

        public void AddToPokemonInventory(Pokemon pokemon)
        {
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.Connection);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = @"CALL inventaire_pokemon(@Id);";
                    mySqlCmd.Parameters.AddWithValue("@Id", pokemon.Id);
                    mySqlCmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (mySqlCnn != null)
                {
                    mySqlCnn.Close();
                }
            }
        }

        public void AddToItemInventory(Item item)
        {
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.Connection);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = @"CALL inventaire_items(@Id);";
                    mySqlCmd.Parameters.AddWithValue("@Id", item.Id);
                    mySqlCmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (mySqlCnn != null)
                {
                    mySqlCnn.Close();
                }
            }
        }
    }
}

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

        public int CreateFromReaderItem(MySqlDataReader mySql)
        {
            int id = (int)mySql["ItemId"];

            return id;
        }

        public int CreateFromReaderPokemon(MySqlDataReader mySql)
        {
            int id = (int)mySql["PokemonId"];

            return id;
        }

        public PokemonInventory GetPokemonInventory()
        {
            List<Pokemon> pokemon = new List<Pokemon>();
            List<int> ids = new List<int>();
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
                    ids.Add(CreateFromReaderPokemon(mySqlDataReader));
                }

                foreach (int id in ids)
                {
                    pokemon.Add(_pokemonFactory.Get(id));
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
            List<int> ids = new List<int>();
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
                    ids.Add(CreateFromReaderItem(mySqlDataReader));
                }
                
                foreach(int id in ids)
                {
                    items.Add(_itemFactory.Get(id));
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

        public void DeleteFromItemInventory(Item item)
        {
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.Connection);
                mySqlCnn.Open();

                using (MySqlCommand mySqlCmd = mySqlCnn.CreateCommand())
                {
                    mySqlCmd.CommandText = @"DELETE FROM tbl_inventaireitem WHERE ItemId = @Id LIMIT 1;";
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

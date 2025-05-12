using MySql.Data.MySqlClient;
using PokeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp.DAL.Factories
{
    public class PokemonFactory
    {
        public Pokemon CreateFromReader(MySqlDataReader mySql)
        {
            int id = (int)mySql["PokemonId"];
            string name = mySql["PokemonName"].ToString() ?? "";
            string sprite = mySql["PokemonSpriteFront"].ToString() ?? "";
            string sound = mySql["PokemonSound"].ToString() ?? "";

            return new Pokemon(id, name, sound, sprite);
        }

        public Pokemon Get(int id)
        {
            Pokemon pokemon = new Pokemon();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.Connection);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tbl_pokemons where PokemonId = @Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    pokemon = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return pokemon;
        }

        public Pokemon GetRandom()
        {
            Pokemon pokemon = new Pokemon();
            List<Pokemon> pokemons = new List<Pokemon>();
            Random rnd = new Random();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.Connection);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tbl_pokemons";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    pokemons.Add(CreateFromReader(mySqlDataReader));
                }
                pokemon = pokemons[rnd.Next(pokemons.Count)];
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return pokemon;
        }
    }
}
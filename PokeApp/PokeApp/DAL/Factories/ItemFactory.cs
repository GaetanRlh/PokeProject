using MySql.Data.MySqlClient;
using PokeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp.DAL.Factories
{
    public class ItemFactory
    {
        public Item CreateFromReader(MySqlDataReader mySql)
        {
            int id = (int)mySql["ItemId"];
            string name = mySql["ItemName"].ToString() ?? "";
            decimal price = (decimal)mySql["ItemPrice"];

            return new Item(id, name, price);
        }

        public Item Get(int id)
        {
            Item item = new Item();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.Connection);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tbl_items where ItemId = @Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    item = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return item;
        }
    }
}
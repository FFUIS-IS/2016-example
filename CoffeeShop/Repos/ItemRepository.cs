using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Repos
{
    class ItemRepository
    {
        private static SqlCeConnection connection = DbConnection.Instance.Connection;

        public static Item GetById(int id)
        {
            string sql = "SELECT * FROM Items WHERE id = " + id;

            SqlCeCommand command = new SqlCeCommand(sql, connection);
            SqlCeDataReader reader = command.ExecuteReader();

            reader.Read();

            Item result = new Item((int) reader["Id"], (string) reader["Name"], Convert.ToDouble(reader["Price"]));

            reader.Close();

            return result;
        }

        public static List<Item> GetAll()
        {
            string sql = "SELECT * FROM Items";

            SqlCeCommand command = new SqlCeCommand(sql, connection);
            SqlCeDataReader reader = command.ExecuteReader();

            List<Item> items = new List<Item>();

            while (reader.Read())
            {
                items.Add(new Item((int)reader["Id"], (string)reader["Name"], Convert.ToDouble(reader["Price"])));
            }

            reader.Close();

            return items;
        }

        public static void Update(Item item)
        {
            string sql = "UPDATE items SET name = '" + item.Name + "', price = " + item.Price + " WHERE id = " + item.Id;

            SqlCeCommand command = new SqlCeCommand(sql, connection);
            command.ExecuteReader();
        }

        public static void Delete(Item item)
        {
            string sql = "DELETE FROM items WHERE id = " + item.Id;

            SqlCeCommand command = new SqlCeCommand(sql, connection);
            command.ExecuteReader();
        }
    }
}

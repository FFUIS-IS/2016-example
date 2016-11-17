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
        public static Item GetById(int id)
        {
            SqlCeConnection connection = DbConnection.Instance.Connection;

            SqlCeCommand command = new SqlCeCommand("SELECT * FROM Items WHERE id = " + id, connection);
            SqlCeDataReader reader = command.ExecuteReader();

            reader.Read();

            Item result = new Item((int) reader["Id"], (string) reader["Name"], Convert.ToDouble(reader["Price"]));

            reader.Close();

            return result;
        }
    }
}

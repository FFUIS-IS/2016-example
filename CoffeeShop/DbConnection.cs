using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    class DbConnection
    {
        private static DbConnection instance;

        private SqlCeConnection connection;

        private DbConnection()
        {
            string dbPassword = File.ReadAllText(@"..\..\config.txt");
            string connectionString = @"Data Source=..\..\..\CoffeeShopDatabase.sdf;Password=" + dbPassword;

            connection = new SqlCeConnection(connectionString);
            connection.Open();
        }

        public static DbConnection Instance
        {
            get
            {
                if (instance == null)
                    instance = new DbConnection();

                return instance;
            }
        }

        public SqlCeConnection Connection
        {
            get
            {
                return connection;
            }
        }
    }
}

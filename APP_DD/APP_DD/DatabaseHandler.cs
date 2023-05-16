using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace APP_DD
{
    public class DatabaseHandler
    {
        private readonly string connectionString; // строка подключения к базе данных

        public DatabaseHandler(string connectionString)
        {
            this.connectionString = connectionString;
        }

    }
}


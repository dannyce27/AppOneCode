using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOneCode.Modelo
{
    public class Conexion
    {



        private SqlConnection connection;
        private readonly string connectionString = "Server=DESKTOP-8FODO0C\\SQLEXPRESS02;Database=AppOnecodeDB;Trusted_Connection=True;";

        public SqlConnection OpenConnection()
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            return connection;
        }

        public void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

    }
}

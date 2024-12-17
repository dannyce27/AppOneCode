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

         


        private static string servidor = "DESKTOP-8FODO0C\\SQLEXPRESS02";
        private static string baseDeDatos = "AppOnecodeDB";
        private string cadena;

        public static SqlConnection Conectar()
        {
            string cadena =
                $"Data Source={servidor};" +
                $" Initial Catalog={baseDeDatos};" +
                $" Integrated Security= true;";

            SqlConnection con = new SqlConnection(cadena);

            con.Open();

            return con;
        }


    }
}

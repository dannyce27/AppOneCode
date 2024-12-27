using AppOneCode.Modelo;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

public class Usuario
{
    public static int Crearcuentas(string usuario, string email, string password)
    {
        int resultado = 0;

        // Hash de la contraseña
      //  string hashedPassword = HashPassword(password);

        using (SqlConnection Conn = new Conexion().OpenConnection())
        {
            string query = "INSERT INTO Users (Username, Email, Contrasenaa) VALUES (@Username, @Email, @Contrasenaa)";

            using (SqlCommand Comando = new SqlCommand(query, Conn))
            {
                Comando.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar) { Value = usuario });
                Comando.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email });
                Comando.Parameters.Add(new SqlParameter("@Contrasenaa", SqlDbType.NVarChar) { Value = password });

                try
                {
                    resultado = Comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error de SQL: {ex.Message}\nCódigo: {ex.Number}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        return resultado;
    }

   // private static string HashPassword(string password)
  //  {
  //      using (SHA256 sha256 = SHA256.Create())
     //   {
       //     byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        //    StringBuilder builder = new StringBuilder();
        //    foreach (byte b in bytes)
        //    {
         //       builder.Append(b.ToString("x2"));
        //    }
           // return builder.ToString();
        }
    

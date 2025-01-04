using AppOneCode;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System;

public class Usuario
{
    // Método para crear cuentas
    public static bool CrearCuentas(string usuario, string email, string password)
    {
        // Validación de entrada
        if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Hash de la contraseña
        string hashedPassword = HashPassword(password);

        using (SqlConnection conn = new Conexion().OpenConnection())
        {
            string query = "INSERT INTO Users (Username, Email, Contrasenaa) VALUES (@Username, @Email, @Contrasenaa)";
            using (SqlCommand comando = new SqlCommand(query, conn))
            {
                // Agregar parámetros
                comando.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar) { Value = usuario });
                comando.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email });
                comando.Parameters.Add(new SqlParameter("@Contrasenaa", SqlDbType.NVarChar) { Value = hashedPassword });

                try
                {
                    // Si `ExecuteNonQuery` devuelve más de 0 filas afectadas, la inserción fue exitosa
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error de SQL: {ex.Message}\nCódigo: {ex.Number}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }

    // Método para verificar cuenta
    public static bool VerificarCuenta(string usuario, string password, Form formularioActual)
    {

        string hashedPassword = HashPassword(password);

        using (SqlConnection conn = new Conexion().OpenConnection())
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Contrasenaa = @Contrasenaa";

            using (SqlCommand comando = new SqlCommand(query, conn))
            {
                comando.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar) { Value = usuario });
                comando.Parameters.Add(new SqlParameter("@Contrasenaa", SqlDbType.NVarChar) { Value = hashedPassword });

                try
                {
                    int count = (int)comando.ExecuteScalar();

                    return count > 0;
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

        return false;
    }

    
 

    // Método para hash de contraseñas
    private static string HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("La contraseña no puede ser nula o vacía.", nameof(password));

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLowerInvariant();
        }
    }
}

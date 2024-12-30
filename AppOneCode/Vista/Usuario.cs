using AppOneCode;
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
        string hashedPassword = HashPassword(password);

        using (SqlConnection Conn = new Conexion().OpenConnection())
        {
            string query = "INSERT INTO Users (Username, Email, Contrasenaa) VALUES (@Username, @Email, @Contrasenaa)";

            using (SqlCommand Comando = new SqlCommand(query, Conn))
            {
                Comando.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar) { Value = usuario });
                Comando.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email });
                Comando.Parameters.Add(new SqlParameter("@Contrasenaa", SqlDbType.NVarChar) { Value = hashedPassword });

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


    public static bool VerificarCuenta(string usuario, string password, Form formularioActual)
    {
        // Hash de la contraseña ingresada por el usuario
        string hashedPassword = HashPassword(password);

        using (SqlConnection Conn = new Conexion().OpenConnection())
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Contrasenaa = @Contrasenaa";

            using (SqlCommand Comando = new SqlCommand(query, Conn))
            {
                Comando.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar) { Value = usuario });
                Comando.Parameters.Add(new SqlParameter("@Contrasenaa", SqlDbType.NVarChar) { Value = hashedPassword });

                try
                {
                    // Verificar si existe una cuenta con las credenciales proporcionadas
                    int count = (int)Comando.ExecuteScalar();

                    if (count > 0)
                    {
                        // Credenciales correctas: abrir formulario FrmInicio
                        MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Abrir el formulario FrmInicio
                        FrmInicio frmInicio = new FrmInicio();
                        formularioActual.Hide(); // Ocultar el formulario actual
                        frmInicio.Show();
                        return true;
                    }
                    else
                    {
                        // Credenciales incorrectas
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
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



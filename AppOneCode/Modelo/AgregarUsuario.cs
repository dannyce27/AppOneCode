using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace AppOneCode.Modelo
{
    public class AgregarUsuario
    {
        public static int UsuarioId { get; set; }


        //Metodo para cargar usuarios
        public static void CargarUsuarios(DataGridView dgv)
        {
            using (SqlConnection conn = new Conexion().OpenConnection())
            {
                string query = "SELECT Id, Username, Email FROM Users"; // Selecciona los campos que deseas mostrar
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv.DataSource = dt; // Asigna el DataTable como fuente de datos del DataGridView
                }
            }
        }

        // Método para crear cuentas

        public static bool CrearCuentas(string usuario, string email, string password, DataGridView dgv)
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
                        if (filasAfectadas > 0)
                        {
                            // Cargar usuarios en el DataGridView
                            CargarUsuarios(dgv);
                            return true;
                        }
                        return false;
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
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool EliminarCuenta(int usuarioId, DataGridView dgv)
        {
            using (SqlConnection conn = new Conexion().OpenConnection())
            {
                string query = "DELETE FROM Users WHERE Id = @Id";
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = usuarioId });

                    try
                    {
                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            // Cargar usuarios en el DataGridView
                            CargarUsuarios(dgv);
                            return true;
                        }
                        return false;
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

        public static bool EditarCuenta(int usuarioId, string nuevoUsuario, string nuevoEmail, string nuevaContraseña, DataGridView dgv)
        {
            // Validación de entrada
            if (string.IsNullOrEmpty(nuevoUsuario) || string.IsNullOrEmpty(nuevoEmail) || string.IsNullOrEmpty(nuevaContraseña))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Hash de la nueva contraseña
            string hashedPassword = HashPassword(nuevaContraseña);

            using (SqlConnection conn = new Conexion().OpenConnection())
            {
                string query = "UPDATE Users SET Username = @Username, Email = @Email, Contrasenaa = @Contrasenaa WHERE Id = @Id";
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    // Agregar parámetros
                    comando.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar) { Value = nuevoUsuario });
                    comando.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar) { Value = nuevoEmail });
                    comando.Parameters.Add(new SqlParameter("@Contrasenaa", SqlDbType.NVarChar) { Value = hashedPassword });
                    comando.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = usuarioId });

                    try
                    {
                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            // Cargar usuarios en el DataGridView
                            CargarUsuarios(dgv);
                            return true;
                        }
                        return false;
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





    }
}
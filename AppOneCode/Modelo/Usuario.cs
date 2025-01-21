using AppOneCode;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System;

public class Usuario
{
    public static int UsuarioId { get; set; }

    // Método para crear cuentas


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
    public static int VerificarCuenta(string usuario, string password, AppOneCode.Vista.FrmLogin frmLogin)
    {
        string hashedPassword = HashPassword(password);

        using (SqlConnection conn = new Conexion().OpenConnection())
        {
            string query = "SELECT Id FROM Users WHERE Username = @Username AND Contrasenaa = @Contrasenaa";

            using (SqlCommand comando = new SqlCommand(query, conn))
            {
                comando.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar) { Value = usuario });
                comando.Parameters.Add(new SqlParameter("@Contrasenaa", SqlDbType.NVarChar) { Value = hashedPassword });

                try
                {
                    object result = comando.ExecuteScalar();

                    if (result != null)
                    {
                        // Si las credenciales son correctas, devolvemos el usuarioId
                        return Convert.ToInt32(result);
                    }
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

        return -1; // Si no se encuentra al usuario, devolvemos -1
    }


    // Método para guardar la imagen en la base de datos
    public static bool GuardarImagenUsuario(int usuarioId, byte[] imagen)
    {
        try
        {
            using (SqlConnection conn = new Conexion().OpenConnection())
            {
                string query = "UPDATE Users SET ImagenPerfil = @ImagenPerfil WHERE Id = @UsuarioId";
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int) { Value = usuarioId });
                    comando.Parameters.Add(new SqlParameter("@ImagenPerfil", SqlDbType.VarBinary) { Value = imagen });

                    // Ejecutar el comando
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        catch (SqlException ex)
        {
            // Mostrar el error completo
            MessageBox.Show($"Error de SQL: {ex.Message}\nCódigo: {ex.Number}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        catch (Exception ex)
        {
            // Mostrar el error general
            MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    // Método para cargar la imagen desde la base de datos
    public static byte[] CargarImagenUsuario(int usuarioId)
    {
        try
        {
            using (SqlConnection conn = new Conexion().OpenConnection())
            {
                string query = "SELECT ImagenPerfil FROM Users WHERE Id = @UsuarioId";
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int) { Value = usuarioId });

                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["Imagen"] as byte[];
                    }
                    return null;
                }
            }
        }
        catch (SqlException ex) 
        {
            MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }

    public static string ObtenerNombreUsuario(int usuarioId)
    {
        try
        {
            using (SqlConnection conn = new Conexion().OpenConnection())
            {
                string query = "SELECT Username FROM Users WHERE Id = @UsuarioId";
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int) { Value = usuarioId });

                    object result = comando.ExecuteScalar();

                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return null;
    }// Si no se encuentra el usuario


    public static string ObtenerEmailUsuario(int usuarioId)
    {
        try
        {
            using (SqlConnection conn = new Conexion().OpenConnection())
            {
                string query = "SELECT Email FROM Users WHERE Id = @UsuarioId";
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int) { Value = usuarioId });

                    object result = comando.ExecuteScalar();

                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return null; // Si no se encuentra el email
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

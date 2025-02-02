using AppOneCode;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System;
using AppOneCode.Modelo;
using System.Collections.Generic;

public class Usuario
{
    public static int UsuarioId { get; set; }
    public int Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Contrasenaa { get; private set; }

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
            // Inicialización de la variable para el tipo de usuario
            int idTipoUsuario;

            try
            {
                // Comprobar si hay usuarios en la base de datos
                string queryComprobarUsuarios = "SELECT COUNT(*) FROM Users";
                using (SqlCommand comandoComprobar = new SqlCommand(queryComprobarUsuarios, conn))
                {
                    int count = (int)comandoComprobar.ExecuteScalar();
                    // Si no hay registros, asignar tipo de usuario como 1 (Administrador)
                    idTipoUsuario = (count == 0) ? 1 : 2; // 1 para Administrador, 2 para Empleado
                }

                // Ahora insertar el nuevo usuario con el idTipoUsuario correspondiente
                string queryInsertar = @"
            INSERT INTO Users (Username, Email, Contrasenaa, idTipoUsuario) 
            VALUES (@Username, @Email, @Contrasenaa, @idTipoUsuario)";

                using (SqlCommand comandoInsertar = new SqlCommand(queryInsertar, conn))
                {
                    comandoInsertar.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar) { Value = usuario });
                    comandoInsertar.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email });
                    comandoInsertar.Parameters.Add(new SqlParameter("@Contrasenaa", SqlDbType.NVarChar) { Value = hashedPassword });
                    comandoInsertar.Parameters.Add(new SqlParameter("@idTipoUsuario", SqlDbType.Int) { Value = idTipoUsuario });

                    int filasAfectadas = comandoInsertar.ExecuteNonQuery();
                    return filasAfectadas > 0;
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
                string query = "SELECT ImagenPerfil FROM Users WHERE Id = @Id";
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = usuarioId });

                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["ImagenPerfil"] as byte[];
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

    public List<Usuario> BuscarUsuarios(string usuario)
    {
        string connectionString = @"Server=DESKTOP-2I6K8G4\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;";
        List<Usuario> tareasList = new List<Usuario>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT  Username, email FROM Users WHERE Username LIKE @Criterio OR Email LIKE @Criterio";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Criterio", "%" + usuario + "%"); // Búsqueda con comodines

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario_ = new Usuario
                    {

                        Username = reader.GetString(0),
                        Email = reader.GetString(1)


                    };
                    tareasList.Add(usuario_);
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
        }

        return tareasList;
    }

    public int ContarUsuarios()
    {
        int numeroUsuarios = 0;

        using (SqlConnection conn = new Conexion().OpenConnection())
        {
            string query = "SELECT COUNT(*) FROM Users";

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                numeroUsuarios = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        return numeroUsuarios;
    }

   public bool CambiarContraseñaPorCorreo(string email, string nuevaContraseña)
{
    try
    {
        string contraseñaEncriptada = EncriptarContraseña(nuevaContraseña);

        using (SqlConnection conn = new Conexion().OpenConnection())
        {
            string query = "UPDATE Users SET Contrasenaa = @Contrasenaa WHERE Email = @Email";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Contrasenaa", contraseñaEncriptada);
                cmd.Parameters.AddWithValue("@Email", email);

                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0; // Retorna true si al menos una fila fue actualizada
            }
        }
    }
    catch (SqlException ex)
    {
        MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }
}

    private string EncriptarContraseña(string contraseña)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }

}

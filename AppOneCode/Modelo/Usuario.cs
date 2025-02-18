using AppOneCode;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System;
using AppOneCode.Modelo;
using System.Collections.Generic;
using AppOneCode.Vista;
using System.IO;
using System.Linq;
using System.Drawing;

public class Usuario
{
    public static int UsuarioId { get; set; }
    public int Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Contrasenaa { get; private set; }

    public int idTipoUsuario { get; private set; }

    public byte[] ImagenPerfil { get; set; }



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
        string connectionString = @"Server=DESKTOP-8FODO0C\SQLEXPRESS02;Database=BDOneCode;Trusted_Connection=True;";
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

        using (SqlConnection conn = new Conexion().OpenConnection()) // La conexión ya está abierta
        {
            string query = "SELECT COUNT(*) FROM Users";

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                numeroUsuarios = (int)cmd.ExecuteScalar(); // Ejecuta la consulta directamente
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

    public static int ObtenerIdTipoUsuario(int usuarioId)
    {
        try
        {
            using (SqlConnection conn = new Conexion().OpenConnection())
            {
                string query = "SELECT idTipoUsuario FROM Users WHERE Id = @UsuarioId";
                using (SqlCommand comando = new SqlCommand(query, conn))
                {
                    comando.Parameters.Add(new SqlParameter("@UsuarioId", SqlDbType.Int) { Value = usuarioId });

                    object result = comando.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1; // Retorna -1 si no encuentra el usuario
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

        return -1;
    }


    public static string ObtenerTipoUsuario(int usuarioId)
    {
        string tipoUsuario = "";

        // Aquí debes agregar la lógica para obtener el tipo de usuario desde la base de datos.
        using (SqlConnection conn = new Conexion().OpenConnection())
        {
            string query = "SELECT tu.NombreTipoUsuario \r\n                         FROM Users u\r\n                         INNER JOIN TipoUsuario tu ON u.idTipoUsuario = tu.idTipoUsuario\r\n                         WHERE u.Id = @UsuarioId   ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);

            try
            {
                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    tipoUsuario = resultado.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el TipoUsuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        return tipoUsuario;
    }

    public void LlenarUsuarios(FlowLayoutPanel contenedor)
    {
        using (SqlConnection conn = new Conexion().OpenConnection())
        {
            string query = "SELECT Id, Username, ImagenPerfil FROM Users";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;

            try
            {

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    // Obtener valores de la BD
                    int id = rd["Id"] != DBNull.Value ? Convert.ToInt32(rd["Id"]) : 0;
                    string nombre = rd["Username"] != DBNull.Value ? rd["Username"].ToString() : string.Empty;
                    byte[] imagenBytes = rd["ImagenPerfil"] != DBNull.Value ? (byte[])rd["ImagenPerfil"] : null;

                    // Crear una nueva instancia de UserControl
                    user userControl = new user
                    {
                        Id = id,
                        Name = nombre
                    };

                    // Asignar nombre al Label
                    Label lblNombreUsuario = (Label)userControl.Controls.Find("lblNombreUsuario", true).FirstOrDefault();
                    if (lblNombreUsuario != null)
                    {
                        lblNombreUsuario.Text = nombre;
                    }

                    // Asignar imagen al PictureBox
                    PictureBox pbFotoPerfil = (PictureBox)userControl.Controls.Find("pbFotoPerfil", true).FirstOrDefault();
                    if (pbFotoPerfil != null && imagenBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imagenBytes))
                        {
                            pbFotoPerfil.Image = Image.FromStream(ms);
                            pbFotoPerfil.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }

                    // Agregar al contenedor
                    contenedor.Controls.Add(userControl);
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }
    }

    public static List<Usuario> ObtenerUsuarios()
    {
        List<Usuario> listaUsuarios = new List<Usuario>();

        using (SqlConnection conn = new Conexion().OpenConnection())
        {
            string query = "SELECT Id, Username, Email, idTipoUsuario FROM Users";
            using (SqlCommand comando = new SqlCommand(query, conn))
            {
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Email = reader.GetString(2),
                        idTipoUsuario = reader.GetInt32(3)
                    };
                    listaUsuarios.Add(usuario);
                }
            }
        }

        return listaUsuarios;
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

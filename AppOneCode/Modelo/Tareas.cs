using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppOneCode.Modelo
{
    public class Tareas
    {
        private readonly string connectionString = "Server=DESKTOP-JVGVM0A\\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;";

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Encargado { get; set; }
        public string AreaDeTrabajo { get; set; }
        public string Descripcion { get; set; }

        public bool InsertarProyecto()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Trabajo (Nombre, Encargado, AreaDeTrabajo, Descripcion) VALUES (@Nombre, @Encargado, @AreaDeTrabajo, @Descripcion)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Encargado", Encargado);
                cmd.Parameters.AddWithValue("@AreaDeTrabajo", AreaDeTrabajo);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion ?? (object)DBNull.Value); // Manejo de null

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Retorna true si se insertó al menos una fila
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
        }


        public List<Tareas> BuscarProyecto(string criterio)
        {
            List<Tareas> tareasList = new List<Tareas>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nombre, Encargado, AreaDeTrabajo, Descripcion FROM Trabajo WHERE Nombre LIKE @Criterio";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Criterio", "%" + criterio + "%"); // Búsqueda con comodines

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Tareas tarea = new Tareas
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Encargado = reader.GetString(2),
                            AreaDeTrabajo = reader.GetString(3),
                            Descripcion = reader.IsDBNull(4) ? null : reader.GetString(4)
                        };
                        tareasList.Add(tarea);
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


        // Método para cargar todas las tareas
        public List<Tareas> CargarProyecto()
        {
            List<Tareas> tareasList = new List<Tareas>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nombre, Encargado, AreaDeTrabajo, Descripcion FROM Trabajo";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Tareas tarea = new Tareas
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Encargado = reader.GetString(2),
                            AreaDeTrabajo = reader.GetString(3),
                            Descripcion = reader.IsDBNull(4) ? null : reader.GetString(4)
                        };
                        tareasList.Add(tarea);
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

        // Método para actualizar una tarea
        public bool ActualizarProyecto()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Trabajo SET Nombre = @Nombre, Encargado = @Encargado, AreaDeTrabajo = @AreaDeTrabajo, Descripcion = @Descripcion WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Encargado", Encargado);
                cmd.Parameters.AddWithValue("@AreaDeTrabajo", AreaDeTrabajo);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion ?? (object)DBNull.Value); // Manejo de null

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Retorna true si se actualizó al menos una fila
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
        }

        // Método para eliminar una tarea
        public bool EliminarProyecto()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Trabajo WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", Id);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Retorna true si se eliminó al menos una fila
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
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AppOneCode.Modelo
{
    public class Tareas
    {
        private readonly string connectionString = @"Server=localhost\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;";


        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdEncargado { get; set; }
        public int IdAreaTrabajo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }


        public bool InsertarProyecto()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Trabajo (Nombre, IdEncargado, IdAreaTrabajo, Descripcion, FechaInicio, FechaFinalizacion) 
                                 VALUES (@Nombre, @IdEncargado, @IdAreaTrabajo, @Descripcion, @FechaInicio, @FechaFinalizacion)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@IdEncargado", IdEncargado);
                cmd.Parameters.AddWithValue("@IdAreaTrabajo", IdAreaTrabajo);
                cmd.Parameters.AddWithValue("@Descripcion", (object)Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFinalizacion", FechaFinalizacion);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        public List<Tareas> BuscarProyecto(string criterio)
        {
            List<Tareas> tareasList = new List<Tareas>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT Id, Nombre, IdEncargado, IdAreaTrabajo, Descripcion, FechaInicio, FechaFinalizacion 
                                 FROM Trabajo WHERE Nombre LIKE @Criterio";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        tareasList.Add(new Tareas
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            IdEncargado = reader.GetInt32(2),
                            IdAreaTrabajo = reader.GetInt32(3),
                            Descripcion = reader.IsDBNull(4) ? null : reader.GetString(4),
                            FechaInicio = reader.GetDateTime(5),
                            FechaFinalizacion = reader.GetDateTime(6)
                        });
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return tareasList;
        }


        public List<Tareas> CargarProyecto()
        {
            List<Tareas> tareasList = new List<Tareas>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT Id, Nombre, IdEncargado, IdAreaTrabajo, Descripcion, FechaInicio, FechaFinalizacion FROM Trabajo";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        tareasList.Add(new Tareas
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            IdEncargado = reader.GetInt32(2),
                            IdAreaTrabajo = reader.GetInt32(3),
                            Descripcion = reader.IsDBNull(4) ? null : reader.GetString(4),
                            FechaInicio = reader.GetDateTime(5),
                            FechaFinalizacion = reader.GetDateTime(6)
                        });
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return tareasList;
        }


        public bool ActualizarProyecto()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Trabajo 
                                 SET Nombre = @Nombre, IdEncargado = @IdEncargado, IdAreaTrabajo = @IdAreaTrabajo, 
                                     Descripcion = @Descripcion, FechaInicio = @FechaInicio, FechaFinalizacion = @FechaFinalizacion
                                 WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@IdEncargado", IdEncargado);
                cmd.Parameters.AddWithValue("@IdAreaTrabajo", IdAreaTrabajo);
                cmd.Parameters.AddWithValue("@Descripcion", (object)Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFinalizacion", FechaFinalizacion);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


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
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        
        

    }
}

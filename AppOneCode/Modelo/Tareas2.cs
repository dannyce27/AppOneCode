using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AppOneCode.Vista;

namespace AppOneCode.Modelo
{
    public class Tareas2
    {
        string connectionString = "Server=DESKTOP-8FODO0C\\SQLEXPRESS02;Database=BDOneCode;Trusted_Connection=True;";

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Usuario { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public string Trabajo { get; set; }

        // Método para insertar una nueva tarea
        public bool InsertarTarea()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO Tareas (Descripcion, UsuarioId, PrioridadId, EstadoId, FechaInicio, FechaFinalizacion, idProyecto)
            VALUES (
                @Descripcion, 
                (SELECT Id FROM Users WHERE Username = @Usuario), 
                (SELECT Id FROM Prioridad WHERE NombrePrioridad = @Prioridad), 
                (SELECT Id FROM Estado WHERE NombreEstado = @Estado),
                @FechaInicio,
                @FechaFinalizacion, 
                (SELECT Id FROM Trabajo WHERE Nombre = @Trabajo)
            )";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Prioridad", Prioridad);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFinalizacion", FechaFinalizacion);
                cmd.Parameters.AddWithValue("@Trabajo", Trabajo);  // Se utiliza la subconsulta para obtener el Id del proyecto

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


        public List<Tareas2> BuscarTareas(string criterio)
        {
            List<Tareas2> tareasList = new List<Tareas2>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
              SELECT T.Id, T.Descripcion, U.Username AS Usuario, P.NombrePrioridad AS Prioridad, E.NombreEstado AS Estado, T.FechaInicio AS Fecha_Inicio, T.FechaFinalizacion AS Fecha_Finalizacion, PR.Nombre AS NombreProyecto
              FROM Tareas T
              INNER JOIN Users U ON T.UsuarioId = U.Id
              INNER JOIN Prioridad P ON T.PrioridadId = P.Id
              INNER JOIN Estado E ON T.EstadoId = E.Id
             INNER JOIN Trabajo PR ON T.idProyecto = PR.Id
              WHERE T.Descripcion LIKE @Criterio";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Tareas2 tarea = new Tareas2
                        {
                            Id = reader.GetInt32(0),
                            Descripcion = reader.GetString(1),
                            Usuario = reader.GetString(2),
                            Prioridad = reader.GetString(3),
                            Estado = reader.GetString(4),
                            FechaInicio = reader.GetDateTime(5),
                            FechaFinalizacion = reader.GetDateTime(6),
                            Trabajo = reader.GetString(7),
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
        public List<Tareas2> CargarTareas()
        {
            List<Tareas2> tareasList = new List<Tareas2>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT T.Id, 
                   T.Descripcion, 
                   U.Username AS Usuario, 
                   P.NombrePrioridad AS Prioridad, 
                   E.NombreEstado AS Estado,
                   T.FechaInicio, 
                   T.FechaFinalizacion,
                   PR.Nombre AS NombreProyecto
            FROM Tareas T
            INNER JOIN Users U ON T.UsuarioId = U.Id
            INNER JOIN Prioridad P ON T.PrioridadId = P.Id
            INNER JOIN Estado E ON T.EstadoId = E.Id
            INNER JOIN Trabajo PR ON T.idProyecto = PR.Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Tareas2 tarea = new Tareas2
                        {
                            Id = reader.GetInt32(0),
                            Descripcion = reader.GetString(1),
                            Usuario = reader.GetString(2),
                            Prioridad = reader.GetString(3),
                            Estado = reader.GetString(4),
                            FechaInicio = reader.GetDateTime(5),
                            FechaFinalizacion = reader.GetDateTime(6),
                            Trabajo = reader.GetString(7)
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
        public bool ActualizarTarea()
        {
            // Validar que las fechas estén dentro del rango permitido por SQL Server.
            // El mínimo permitido para SqlDateTime es: 1/1/1753 12:00:00 AM
            DateTime fechaInicioValida = FechaInicio < (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue
                ? (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue
                : FechaInicio;
            DateTime fechaFinalizacionValida = FechaFinalizacion < (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue
                ? (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue
                : FechaFinalizacion;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            UPDATE Tareas
            SET 
                Descripcion = @Descripcion,
                UsuarioId = (SELECT Id FROM Users WHERE Username = @Users),
                PrioridadId = (SELECT Id FROM Prioridad WHERE NombrePrioridad = @Prioridad),
                EstadoId = (SELECT Id FROM Estado WHERE NombreEstado = @Estado),
                FechaInicio = @FechaInicio,
                FechaFinalizacion = @FechaFinalizacion,
                idProyecto = (SELECT Id FROM Trabajo WHERE Nombre = @Trabajo)
            WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Users", Usuario);
                cmd.Parameters.AddWithValue("@Prioridad", Prioridad);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicioValida);
                cmd.Parameters.AddWithValue("@FechaFinalizacion", fechaFinalizacionValida);
                cmd.Parameters.AddWithValue("@Trabajo", Trabajo);

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


        // Método para eliminar una tarea
        public bool EliminarTarea()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Tareas WHERE Id = @Id";
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public void LLenarTareas(FlowLayoutPanel contenedor)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Consulta SQL con JOIN para obtener los nombres de Prioridad y Estado
                string query = "SELECT t.Id, t.Descripcion, u.Username AS Usuario, p.NombrePrioridad AS Prioridad, e.NombreEstado AS Estado " +
                               "FROM Tareas t " +
                               "JOIN Users u ON t.UsuarioId = u.Id " +
                               "JOIN Prioridad p ON t.PrioridadId = p.Id " +
                               "JOIN Estado e ON t.EstadoId = e.Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;

                try
                {
                    conn.Open();
                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        // Asegúrate de que los datos no sean null antes de asignarlos
                        int id = rd["Id"] != DBNull.Value ? Convert.ToInt32(rd["Id"]) : 0;
                        string descripcion = rd["Descripcion"] != DBNull.Value ? rd["Descripcion"].ToString() : string.Empty;
                        string usuario = rd["Usuario"] != DBNull.Value ? rd["Usuario"].ToString() : string.Empty;
                        string prioridad = rd["Prioridad"] != DBNull.Value ? rd["Prioridad"].ToString() : string.Empty;
                        string estado = rd["Estado"] != DBNull.Value ? rd["Estado"].ToString() : string.Empty;

                        // Crear un nuevo UserControlTareas
                        UserControlTareas userControlTareas = new UserControlTareas
                        {
                            Id = id,
                            Descripcion = descripcion,
                            Prioridad = prioridad,
                            Estado = estado
                        };

                        // Agregar el UserControl al contenedor (FlowLayoutPanel)
                        contenedor.Controls.Add(userControlTareas);
                    }

                    conn.Close();
                    conn.Dispose();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Este es el error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Se ha producido un error inesperado: {ex.Message}");
                }
            }
        }

        public bool ActualizarEstado()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            UPDATE Tareas
            SET EstadoId = (SELECT Id FROM Estado WHERE NombreEstado = @Estado)
            WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Estado", Estado);

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
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public int ObtenerTareasCompletadasPorUsuario(int usuarioId)
        {
            int tareasCompletadas = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT COUNT(*) 
            FROM Tareas 
            WHERE UsuarioId = @UsuarioId AND EstadoId = (
                SELECT Id FROM Estado WHERE NombreEstado = 'Completada'
            )";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioId", usuarioId);

                connection.Open();
                tareasCompletadas = (int)command.ExecuteScalar();
            }
            return tareasCompletadas;
        }

        public string ObtenerNombreUsuarioAsignado(int tareaId)
        {
            string encargado = null;

            string query = @"
                SELECT U.Username 
                FROM Users U
                INNER JOIN Tareas T ON U.Id = T.UsuarioId
                WHERE T.Id = @TareaId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TareaId", tareaId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    encargado = reader["Username"].ToString();
                }
            }

            return encargado;
        }


        public void ActualizarNumeroTareasCompletadas(int usuarioId, Label lblNumeroTC)
        {
            try
            {
                // Llamar al método para obtener el número de tareas completadas
                int tareasCompletadas = ObtenerTareasCompletadasPorUsuario(usuarioId);

                // Actualizar el Label con el nuevo número de tareas completadas
                lblNumeroTC.Text = tareasCompletadas.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar las tareas completadas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Tareas2> ObtenerTareas()
        {
            List<Tareas2> tareas = new List<Tareas2>();



            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT t.Id, t.Descripcion, u.Username AS Usuario, p.NombrePrioridad AS Prioridad, e.NombreEstado AS Estado " +
                               "FROM Tareas t " +
                               "JOIN Users u ON t.UsuarioId = u.Id " +
                               "JOIN Prioridad p ON t.PrioridadId = p.Id " +
                               "JOIN Estado e ON t.EstadoId = e.Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;

                try
                {
                    conn.Open();
                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        // Crear y agregar objetos Tareas2 a la lista
                        Tareas2 tarea = new Tareas2
                        {
                            Id = rd["Id"] != DBNull.Value ? Convert.ToInt32(rd["Id"]) : 0,
                            Descripcion = rd["Descripcion"] != DBNull.Value ? rd["Descripcion"].ToString() : string.Empty,
                            Usuario = rd["Usuario"] != DBNull.Value ? rd["Usuario"].ToString() : string.Empty,
                            Prioridad = rd["Prioridad"] != DBNull.Value ? rd["Prioridad"].ToString() : string.Empty,
                            Estado = rd["Estado"] != DBNull.Value ? rd["Estado"].ToString() : string.Empty
                        };

                        tareas.Add(tarea);
                    }

                    rd.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error en SQL: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inesperado: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }

            return tareas;
        }


        public List<Tareas2> BuscarTareasPorFecha(DateTime fechaInicio, DateTime fechaFinalizacion)
        {
            List<Tareas2> tareasFiltradas = new List<Tareas2>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT T.Id, T.Descripcion, U.Username AS Usuario, 
               P.NombrePrioridad AS Prioridad, E.NombreEstado AS Estado,
               T.FechaInicio, T.FechaFinalizacion, PR.Nombre
        FROM Tareas T
        INNER JOIN Users U ON T.UsuarioId = U.Id
        INNER JOIN Prioridad P ON T.PrioridadId = P.Id
        INNER JOIN Estado E ON T.EstadoId = E.Id
        INNER JOIN Trabajo PR ON T.idProyecto = PR.Id
        WHERE CAST(T.FechaInicio AS DATE) >= @FechaInicio 
          AND CAST(T.FechaFinalizacion AS DATE) <= @FechaFinalizacion";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFinalizacion", fechaFinalizacion);



                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Tareas2 tarea = new Tareas2
                        {
                            Id = reader.GetInt32(0),
                            Descripcion = reader.GetString(1),
                            Usuario = reader.GetString(2),
                            Prioridad = reader.GetString(3),
                            Estado = reader.GetString(4),
                            FechaInicio = reader.GetDateTime(5),
                            FechaFinalizacion = reader.GetDateTime(6),
                            Trabajo = reader.GetString(7)
                        };
                        tareasFiltradas.Add(tarea);

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

            return tareasFiltradas;
        }



    }

}





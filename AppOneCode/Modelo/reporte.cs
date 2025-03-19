using System;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

public class ReportePDF
{
    public static void GenerarReporte()
    {
        try
        {
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "Reporte.pdf");

            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
            {
                Document doc = new Document(PageSize.A4, 30, 30, 25, 25);
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                //estilos de fuente 
                Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.DARK_GRAY);
                Font subtituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLUE);
                Font tareaFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                Font estadoFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.RED);

              
                Paragraph titulo = new Paragraph("Reporte de Tareas", tituloFont)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(titulo);
                doc.Add(new Paragraph("\n"));

  
    string conexionString = @"Server=localhost\SQLEXPRESS;Database=BDOneCode;Trusted_Connection=True;";
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();
                    string query = @"SELECT a.NombreArea, p.Nombre AS Proyecto, t.Descripcion, t.FechaInicio, t.FechaFinalizacion, 
                                         u.Username, e.NombreEstado 
                                      FROM Tareas t
                                      JOIN Trabajo p ON t.idProyecto = p.Id
                                      JOIN AreaTrabajo a ON p.IdAreaTrabajo = a.Id
                                      JOIN Users u ON t.UsuarioId = u.Id
                                      JOIN Estado e ON t.EstadoId = e.Id
                                      ORDER BY a.NombreArea, p.Nombre, t.EstadoId";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string areaActual = "", proyectoActual = "";

                        while (reader.Read())
                        {
                            string area = reader["NombreArea"].ToString();
                            string proyecto = reader["Proyecto"].ToString();
                            string tarea = reader["Descripcion"].ToString();
                            string usuario = reader["Username"].ToString();
                            string estado = reader["NombreEstado"].ToString();
                            string fechaInicio = Convert.ToDateTime(reader["FechaInicio"]).ToShortDateString();
                            string fechaFinal = Convert.ToDateTime(reader["FechaFinalizacion"]).ToShortDateString();

                            
                            if (area != areaActual)
                            {
                                doc.Add(new Paragraph("Área: " + area, subtituloFont));
                                doc.Add(new Paragraph("\n"));
                                areaActual = area;
                            }

                            
                            if (proyecto != proyectoActual)
                            {
                                doc.Add(new Paragraph("Proyecto: " + proyecto, tituloFont));
                                doc.Add(new Paragraph("\n"));
                                proyectoActual = proyecto;
                            }

                          
                            doc.Add(new Paragraph($"Tarea: {tarea}", tareaFont));
                            doc.Add(new Paragraph($"Encargado: {usuario}", tareaFont));
                            doc.Add(new Paragraph($"Estado: {estado}", estadoFont));
                            doc.Add(new Paragraph($"Inicio: {fechaInicio} - Fin: {fechaFinal}", tareaFont));
                            doc.Add(new Paragraph("---------------------------"));
                        }
                    }
                }
                doc.Close();
            }
            Console.WriteLine("Reporte generado con éxito: " + rutaArchivo);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al generar el reporte: " + ex.Message);
        }
    }
}

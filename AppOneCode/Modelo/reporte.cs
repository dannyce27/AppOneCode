using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class ReportePDF
{
    public static void GenerarReporte()
    {
        try
        {
            string rutaArchivo = "Reporte.pdf"; // Ruta donde se guardará el PDF

            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Título del documento
                Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                Paragraph titulo = new Paragraph("Reporte de Tareas", tituloFont);
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);

                doc.Add(new Paragraph("\n")); // Espacio en blanco

                // Agregar contenido de tareas (ejemplo)
                doc.Add(new Paragraph("✅ Tareas Completadas"));
                doc.Add(new Paragraph("- Tarea 1"));
                doc.Add(new Paragraph("- Tarea 2"));
                doc.Add(new Paragraph("\n"));

                doc.Add(new Paragraph("⏳ Tareas Pendientes"));
                doc.Add(new Paragraph("- Tarea 3"));
                doc.Add(new Paragraph("- Tarea 4"));

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

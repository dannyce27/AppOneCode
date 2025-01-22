using System.Net.Mail;
using System.Net;
using System;

public class EmailService
{
    public string EnviarCodigoRecuperacion(string emailDestino)
    {
        try
        {
            // Generar código aleatorio
            Random random = new Random();
            string codigo = random.Next(100000, 999999).ToString();

            // Configuración del cliente SMTP para Zoho Mail
            SmtpClient smtp = new SmtpClient("smtp.zoho.com", 587) // Cambiado a Zoho
            {
                Credentials = new NetworkCredential("tuCorreo@tuDominio.com", "tuContraseñaApp"), // Ingresa tu correo y contraseña de Zoho
                EnableSsl = true
            };

            // Crear el mensaje
            MailMessage mensaje = new MailMessage();
            mensaje.From = new MailAddress("tuCorreo@tuDominio.com"); // Remitente 
            mensaje.To.Add(emailDestino); // Destinatario
            mensaje.Subject = "Código de recuperación de contraseña";
            mensaje.Body = $"Tu código de recuperación es: {codigo}";

            // Enviar el mensaje
            smtp.Send(mensaje);

            return codigo; // Retorna el código generado
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al enviar el correo: {ex.Message}");
        }
    }
}

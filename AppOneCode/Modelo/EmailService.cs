using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppOneCode.Modelo
{
    public class EmailService
    {
        public string EnviarCodigoRecuperacion(string emailDestino)
        {
            try
            {
                // Generar código aleatorio
                Random random = new Random();
                string codigo = random.Next(100000, 999999).ToString();

                // Configuración del cliente SMTP
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("tuCorreo@gmail.com", "tuContraseñaApp"), //ejemplo por ahora, hasta que se cree la cuenta de GMAIL de OneCode
                    EnableSsl = true
                };

                // Crear el mensaje
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("tuCorreo@gmail.com");
                mensaje.To.Add(emailDestino);
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
}

using System.Net.Mail;
using System.Net;
using System;

public class EmailService
{
    public string EnviarCodigoRecuperacion(string emailDestino)
    {
        try
        {
            Random random = new Random();
            string codigo = random.Next(100000, 999999).ToString(); // Generar código

            string mensajeHtml = $@"
        <!DOCTYPE html>
        <html lang='es'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>Código de Recuperación</title>
            <style>
                @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap');
                
                body {{ font-family: 'Poppins', sans-serif; text-align: center; padding: 20px; background-color: #f4f4f4; }}
                .container {{ background-color: #0a192f; padding: 20px; border-radius: 10px; width: 90%; max-width: 400px; margin: auto; 
                             box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); }}
                .title {{ color: #ffffff; font-size: 20px; margin-bottom: 15px; }}
                .code-box {{ background-color: #000; color: #ffffff; font-size: 24px; font-weight: bold; padding: 15px; border-radius: 5px;
                            border: 2px solid #1e90ff; display: inline-block; letter-spacing: 3px; }}
                .footer {{ margin-top: 15px; color: #a0aec0; font-size: 14px; }}
            </style>
        </head>
        <body>
            <div class='container'>
                <h2 class='title'>Código de recuperación</h2>
                <p>Utiliza el siguiente código para restablecer tu contraseña:</p>
                <div class='code-box'>{codigo}</div>
                <p class='footer'>Si no solicitaste este código, ignora este mensaje.</p>
            </div>
        </body>
        </html>";

            SmtpClient smtp = new SmtpClient("smtp.zoho.com", 587)
            {
                Credentials = new NetworkCredential("dsoriano@emkt.com.sv", "DSemkt2024$"),
                EnableSsl = true
            };

            MailMessage mensaje = new MailMessage
            {
                From = new MailAddress("dsoriano@emkt.com.sv"),
                Subject = "Código de recuperación de contraseña",
                Body = mensajeHtml,
                IsBodyHtml = true // ✅ Activar envío en formato HTML
            };

            mensaje.To.Add(emailDestino);
            smtp.Send(mensaje);

            return codigo; // Retorna el código generado
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al enviar el correo: {ex.Message}");
        }

        // Encerramos todo dentro de un trycactch por si habia un error, que no se cerrara la aplicacion por el propio error.
    }
}

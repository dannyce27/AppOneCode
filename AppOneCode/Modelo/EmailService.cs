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
                IsBodyHtml = true
            };

            mensaje.To.Add(emailDestino);
            smtp.Send(mensaje);

            return codigo;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al enviar el correo: {ex.Message}");
        }

        // Encerramos todo dentro de un trycactch por si habia un error, que no se cerrara la aplicacion por el propio error.
    }

    public void EnviarNotificacionTarea(string emailDestino, string nombreUsuario, string nombreProyecto, string descripcionTarea)
    {
        try
        {
            string mensajeHtml = $@"
        <!DOCTYPE html>
        <html lang='es'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>Nueva Tarea Asignada</title>
            <style>
                @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap');
                
                body {{
                    font-family: 'Poppins', sans-serif;
                    background-color: #f4f4f4;
                    text-align: center;
                    padding: 20px;
                }}
                .container {{
                    background-color: #ffffff;
                    padding: 20px;
                    border-radius: 10px;
                    width: 90%;
                    max-width: 500px;
                    margin: auto;
                    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
                }}
                .title {{
                    font-size: 22px;
                    color: #1e90ff;
                    font-weight: bold;
                }}
                .message {{
                    font-size: 16px;
                    color: #333;
                    margin: 15px 0;
                }}
                .task-box {{
                    background-color: #1e90ff;
                    color: #fff;
                    font-size: 18px;
                    font-weight: bold;
                    padding: 10px;
                    border-radius: 5px;
                    display: inline-block;
                }}
                .footer {{
                    margin-top: 15px;
                    font-size: 14px;
                    color: #777;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <h2 class='title'>¡Nueva tarea asignada!</h2>
                <p class='message'>Se te ha asignado una nueva tarea en el proyecto <b>{nombreProyecto}</b>.</p>
                <p class='message'>La tarea consiste en:</p>
                <div class='task-box'>{descripcionTarea}</div>
                <p class='footer'>Por favor, revisa tu panel de tareas para más detalles.</p>
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
                Subject = "Nueva Tarea Asignada",
                Body = mensajeHtml,
                IsBodyHtml = true
            };

            mensaje.To.Add(emailDestino);
            smtp.Send(mensaje);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al enviar el correo: {ex.Message}");
        }



    }

    public void EnviarNotificacionTareaCompletada(string correoEncargado, string username, string usernameCompleto, string nombreProyecto, string descripcionTarea)
    {
        try
        {
            // Crear el objeto MailMessage
            var mail = new MailMessage();
            mail.From = new MailAddress("dsoriano@emkt.com.sv"); // Tu correo electrónico
            mail.To.Add(correoEncargado);
            mail.Subject = "Notificación de tarea completada";

            // HTML para la notificación
            string htmlBody = $@"
                <html>
                    <head>
                        <style>
                            body {{
                                font-family: Arial, sans-serif;
                                background-color: #f4f4f9;
                                padding: 20px;
                            }}
                            .container {{
                                background-color: #ffffff;
                                border-radius: 10px;
                                padding: 20px;
                                border: 1px solid #e0e0e0;
                            }}
                            h2 {{
                                color: #333;
                            }}
                            .highlight {{
                                color: #4CAF50;
                                font-weight: bold;
                            }}
                            .footer {{
                                margin-top: 20px;
                                font-size: 12px;
                                color: #777;
                                text-align: center;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <h2>¡Hola {username}!</h2>
                            <p><span class='highlight'>{usernameCompleto}</span> ha completado la tarea: <span class='highlight'>{descripcionTarea}</span> en el proyecto: <span class='highlight'>{nombreProyecto}</span>.</p>
                            <p>¡Buen trabajo!</p>
                            <div class='footer'>
                                <p>Este es un mensaje automático generado por el sistema de gestión de tareas.</p>
                            </div>
                        </div>
                    </body>
                </html>";

            // Asignar el cuerpo del correo
            mail.Body = htmlBody;
            mail.IsBodyHtml = true;

            // Configuración SMTP
            var smtpClient = new SmtpClient("smtp.zoho.com")
            {
                Port = 587, // Puede ser 587 o 465, dependiendo del servicio
                Credentials = new NetworkCredential("dsoriano@emkt.com.sv", "DSemkt2024$"),
                EnableSsl = true
            };

            // Enviar el correo
            smtpClient.Send(mail);
            Console.WriteLine("Correo enviado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al enviar correo: {ex.Message}");
        }
    }

}

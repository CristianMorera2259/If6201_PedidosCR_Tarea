using System.Net.Mail;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.output;

namespace Ucr.If6201.PedidosCR.Email.SG;

public class EmailAdapter : INotificador
{
    //Se hace la ID de EmailSettings al recibirse por constructor
    private readonly EmailSettings _settings;

    public EmailAdapter(EmailSettings settings)
    {
        _settings = settings;
    }

    public void Enviar(string destinatario, string asunto, string mensaje)
    {
        //Se crea el formato que tiene que llevar el correo y se le adjunta al que lo recibe
        using var mail = new MailMessage
        {
            From = new MailAddress(_settings.Sender),
            Subject = asunto,
            Body = mensaje
        };
        mail.To.Add(destinatario);

        //se conecta al servidor y puerto definido en EmailSettings y se va sin cifrado
        using var smtp = new SmtpClient(_settings.Server, _settings.Port)
        {
            EnableSsl = false
        };
        smtp.Send(mail);
    }
}
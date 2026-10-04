using Ucr.If6201.PedidosCR.Abstracciones.Ports.output;

namespace Ucr.If6201.PedidosCR.Email.SG;

public class EmailAdapter: INotificador
{
    public void Enviar(string destinatario, string asunto, string mensaje)
    {
        throw new NotImplementedException();
    }
}
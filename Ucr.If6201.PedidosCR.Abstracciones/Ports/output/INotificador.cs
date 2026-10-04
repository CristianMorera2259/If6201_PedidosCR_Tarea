namespace Ucr.If6201.PedidosCR.Abstracciones.Ports.output;

public interface INotificador
{
    void Enviar(
        string destinatario,
        string asunto,
        string mensaje);
}
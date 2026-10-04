using Ucr.If6201.PedidosCR.Abstracciones.dtos;

namespace Ucr.If6201.PedidosCR.Abstracciones.Ports.input;

public interface ICancelarPedido
{
    void Ejecutar(int pedidoId);
}
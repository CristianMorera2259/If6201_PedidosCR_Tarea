using Ucr.If6201.PedidosCR.Abstracciones.dtos;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.input;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.output;

namespace Ucr.If6201.PedidosCR.BW.UseCase;

public class CancelarPedidoUseCase: ICancelarPedido
{

    private readonly IPedidoRepository _repository;
    private readonly INotificador _notificador;
    
    public CancelarPedidoUseCase(
        IPedidoRepository repository,
        INotificador notificador)
    {
        _repository = repository;
        _notificador = notificador;
    }


    public void Ejecutar(int pedidoId)
    {
        // Reglas de negocio
        // buscar y cancelar el pedido (cambiar el estado pues)
        // notificar
        // volver
    }
}
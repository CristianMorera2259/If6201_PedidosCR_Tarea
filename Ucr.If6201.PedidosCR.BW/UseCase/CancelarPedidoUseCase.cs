using Ucr.If6201.PedidosCR.Abstracciones.dtos;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.input;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.output;
using Ucr.If6201.PedidosCR.Dominio.Exceptions;

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
        // Reglas de negocio - Buscar y cancelar el pedido (cambiar el estado)- Notificar - volver

        var pedido = _repository.ObtenerPorId(pedidoId);
        if (pedido == null)
            throw new ReglaNegocioException($"No se encontró el pedido con ID {pedidoId}.");

        pedido.Cancelar();
        _repository.Actualizar(pedido);

        _notificador.Enviar(pedido.ClienteEmail, "Cancelación de Pedido", $"Su pedido #{pedido.Id} ha sido cancelado exitosamente.");

    }
}

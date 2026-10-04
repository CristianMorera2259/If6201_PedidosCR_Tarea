using Ucr.If6201.PedidosCR.Abstracciones.dtos;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.input;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.output;

namespace Ucr.If6201.PedidosCR.BW.UseCase;

public class CrearPedidoUseCase : ICrearPedido
{
    private readonly IPedidoRepository _repository;
    private readonly INotificador _notificador;

    public CrearPedidoUseCase(
        IPedidoRepository repository,
        INotificador notificador)
    {
        _repository = repository;
        _notificador = notificador;
    }

    public PedidoResponse Ejecutar(
        CrearPedidoRequest request)
    {
        // Reglas de negocio
        // Crear pedido
        // Calcular total
        // Guardar
        // Notificar
        // Retornar resultado
        return new PedidoResponse();
    }
}

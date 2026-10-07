using Ucr.If6201.PedidosCR.Abstracciones.dtos;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.input;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.output;
using Ucr.If6201.PedidosCR.Dominio.Entities;

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
       // Reglas de negocio - Crear pedido - Calcular total - Guardar - Notificar - 
       // Retornar resultado

       var pedido = new Pedido
        {
            ClienteId = request.ClienteId,
            ClienteNombre = request.ClienteNombre,
            ClienteEmail = request.ClienteEmail,
            Detalles = request.Detalles.Select(d => new DetallePedido
            {
                ProductoId = d.ProductoId,
                Producto = d.Producto,
                Cantidad = d.Cantidad,
                Precio = d.Precio
            }).ToList()
        };

        pedido.ValidarYCalcularTotal();
        _repository.Guardar(pedido);

        _notificador.Enviar(pedido.ClienteEmail, "Confirmación de Pedido", $"Su pedido #{pedido.Id} ha sido creado por un total de {pedido.Total:C}.");

        return new PedidoResponse {
            Id = pedido.Id,
            ClienteId = pedido.ClienteId,
            ClienteNombre = pedido.ClienteNombre,
            ClienteEmail = pedido.ClienteEmail,
            Estado = pedido.Estado,
            Total = (double)pedido.Total,
            Fecha = pedido.Fecha,
            detalles = pedido.Detalles.Select(detallesReal => new DetallePedidoResponse
            {
                ProductoId = detallesReal.ProductoId,
                Producto = detallesReal.Producto,
                Cantidad = detallesReal.Cantidad,
                Precio = detallesReal.Precio
            }).ToList()};
    }
}

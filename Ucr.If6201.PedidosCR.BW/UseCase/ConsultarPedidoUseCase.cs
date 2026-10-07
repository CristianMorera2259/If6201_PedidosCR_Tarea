using Ucr.If6201.PedidosCR.Abstracciones.dtos;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.input;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.output;
using Ucr.If6201.PedidosCR.Dominio.Entities;

namespace Ucr.If6201.PedidosCR.BW.UseCase;

public class ConsultarPedidoUseCase: IConsultarPedido
{
    private readonly IPedidoRepository _repository;
    
    public ConsultarPedidoUseCase(
        IPedidoRepository repository)
    {
        _repository = repository;
    }

    public PedidoResponse? Ejecutar(int pedidoId)
    {
        // Reglas de negocio - Consultar pedido - Retornar resultado - Tomar en cuenta cuando el id retorna null y tal
        
        var pedido = _repository.ObtenerPorId(pedidoId);
        if (pedido == null) return null;
        
        return new PedidoResponse {
            Id = pedido.Id,
            ClienteId = pedido.ClienteId,
            ClienteNombre = pedido.ClienteNombre,
            ClienteEmail = pedido.ClienteEmail,
            Estado = pedido.Estado.ToString(),
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


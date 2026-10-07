using Ucr.If6201.PedidosCR.Dominio.Enums;
using Ucr.If6201.PedidosCR.Dominio.Exceptions;

namespace Ucr.If6201.PedidosCR.Dominio.Entities;

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string ClienteNombre { get; set; } = string.Empty;
    public string ClienteEmail { get; set; } = string.Empty;
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public EstadoPedido Estado { get; set; } = EstadoPedido.Pendiente;
    public decimal Total { get; set; }
    public List<DetallePedido> Detalles { get; set; } = new();

    public void ValidarYCalcularTotal()
    {
        if (ClienteId <= 0 || string.IsNullOrWhiteSpace(ClienteNombre) || string.IsNullOrWhiteSpace(ClienteEmail))
            throw new ReglaNegocioException("Los datos del cliente son inválidos.");

        if (Detalles == null || !Detalles.Any())
            throw new ReglaNegocioException("El pedido debe tener al menos un producto.");

        if (Detalles.Any(d => d.Cantidad <= 0 || d.Precio <= 0))
            throw new ReglaNegocioException("Las cantidades y precios deben ser mayores que cero.");

        Total = Detalles.Sum(d => d.Subtotal);
        Estado = EstadoPedido.Pendiente;
    }

    public void Cancelar()
    {
        if (Estado != EstadoPedido.Pendiente)
            throw new ReglaNegocioException("Solo se pueden cancelar pedidos en estado Pendiente.");

        Estado = EstadoPedido.Cancelado;
    }
}

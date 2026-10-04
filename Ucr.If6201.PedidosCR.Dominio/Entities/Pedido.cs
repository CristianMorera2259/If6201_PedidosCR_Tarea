using Ucr.If6201.PedidosCR.Dominio.Enums;

namespace Ucr.If6201.PedidosCR.Dominio.Entities;

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string ClienteNombre { get; set; } = string.Empty;
    public string ClienteEmail { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public EstadoPedido Estado { get; set; }
    public double Total { get; set; }
    public List<DetallePedido> Detalles { get; set; } = new();
}
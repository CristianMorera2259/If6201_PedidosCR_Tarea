using Ucr.If6201.PedidosCR.Dominio.Enums;

namespace Ucr.If6201.PedidosCR.Abstracciones.dtos;

public class PedidoResponse
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string ClienteNombre { get; set; } = string.Empty;
    public string ClienteEmail { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public string Estado { get; set; } = string.Empty;
    public double Total { get; set; }
    public List<DetallePedidoResponse> detalles { get; set; } = new List<DetallePedidoResponse>();
    
}
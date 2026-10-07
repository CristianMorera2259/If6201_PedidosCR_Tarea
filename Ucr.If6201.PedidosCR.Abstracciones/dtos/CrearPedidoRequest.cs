namespace Ucr.If6201.PedidosCR.Abstracciones.dtos;

public class CrearPedidoRequest
{
    public int ClienteId { get; set; } = 0;
    public string ClienteNombre { get; set; } = string.Empty;
    public string ClienteEmail { get; set; } = string.Empty;
    public List<DetallePedidoRequest> Detalles { get; set; } = new();
    
}
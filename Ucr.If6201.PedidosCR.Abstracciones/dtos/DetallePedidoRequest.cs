namespace Ucr.If6201.PedidosCR.Abstracciones.dtos;

public class DetallePedidoRequest
{
    public int ProductoId { get; set; } = 0;
    public string Producto { get; set; } = string.Empty;
    public int Cantidad { get; set; } = 0;
    public decimal Precio { get; set; } = 0;
    
}
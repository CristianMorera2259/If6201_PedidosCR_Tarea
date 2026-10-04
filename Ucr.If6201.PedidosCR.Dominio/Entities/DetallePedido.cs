namespace Ucr.If6201.PedidosCR.Dominio.Entities;

public class DetallePedido
{
    public int ProductoId { get; set; }
    public string Producto { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    public decimal Subtotal => Cantidad * Precio;
}
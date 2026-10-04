namespace Ucr.If6201.PedidosCR.Abstracciones.dtos;

public class DetallePedidoResponse
{
    public int ProductoId { get; set; }
    public string Producto { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    public override string ToString()
    {
        return $"""
                Id Producto: {ProductoId}
                Producto: {Producto}
                Cantidad: {Cantidad}
                Precio: {Precio}

                """;
    }
}
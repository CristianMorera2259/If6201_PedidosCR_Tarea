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

    public override string ToString()
    {
        return $"""
                Id Pedido: {Id}
                Id Cliente: {ClienteId}
                Nombre Cliente: {ClienteNombre}
                Email Cliente: {ClienteEmail}
                Fecha: {Fecha}
                Estado: {Estado}
                Total: {Total}
                --- Detalles ---
                {DetallesToString()}
                """;
    }

    private string DetallesToString()
    {
        string finalString = "";
        foreach (var detalle in detalles)
        {
            finalString += detalle.ToString();
        }
        
        return finalString;
    }
}
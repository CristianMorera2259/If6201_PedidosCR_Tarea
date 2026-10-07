using Ucr.If6201.PedidosCR.Abstracciones.Ports.output;
using Ucr.If6201.PedidosCR.Dominio.Entities;
using Microsoft.Data.SqlClient;
using Ucr.If6201.PedidosCR.Dominio.Enums;

namespace Ucr.If6201.PedidosCR.DA.Sql;

public class PedidoRepositySQL : IPedidoRepository
{

    private readonly string _stringConexion;

    // La cadena de conexión llega desde afuera (la Api y la Consola la pasan)
    public PedidoRepositySQL(string stringConexion)
    {
        _stringConexion = stringConexion;
    }

    public void Guardar(Pedido pedido)
    {
        using var conexion = new SqlConnection(_stringConexion);
        conexion.Open();
        using var transaccion = conexion.BeginTransaction();

        //el cmd e¿ guarda yb ibjeto SqlCommand, es el quivalente a prepareStatemente en Java
        using var cmd = new SqlCommand(
            @"INSERT INTO Pedido (ClienteId, ClienteNombre, ClienteEmail, Fecha, Estado, Total)
              OUTPUT INSERTED.Id
              VALUES (@ClienteId, @Nombre, @Email, @Fecha, @Estado, @Total)", conexion, transaccion);
        cmd.Parameters.AddWithValue("@ClienteId", pedido.ClienteId);
        cmd.Parameters.AddWithValue("@Nombre", pedido.ClienteNombre);
        cmd.Parameters.AddWithValue("@Email", pedido.ClienteEmail);
        cmd.Parameters.AddWithValue("@Fecha", pedido.Fecha);
        cmd.Parameters.AddWithValue("@Estado", pedido.Estado.ToString());
        cmd.Parameters.AddWithValue("@Total", pedido.Total);

        pedido.Id = (int)cmd.ExecuteScalar()!; // devuelve el id que se genera

        foreach (var d in pedido.Detalles)
        {
            using var cmdDet = new SqlCommand(
                @"INSERT INTO DetallePedido (PedidoId, ProductoId, Producto, Cantidad, Precio)
                  VALUES (@PedidoId, @ProductoId, @Producto, @Cantidad, @Precio)", conexion, transaccion);
            cmdDet.Parameters.AddWithValue("@PedidoId", pedido.Id);
            cmdDet.Parameters.AddWithValue("@ProductoId", d.ProductoId);
            cmdDet.Parameters.AddWithValue("@Producto", d.Producto);
            cmdDet.Parameters.AddWithValue("@Cantidad", d.Cantidad);
            cmdDet.Parameters.AddWithValue("@Precio", d.Precio);
            cmdDet.ExecuteNonQuery();
        }

        transaccion.Commit();
    }

    public Pedido? ObtenerPorId(int id)
    {
        using var conexion = new SqlConnection(_stringConexion);
        conexion.Open();

        Pedido? pedido = null;
        using (var cmd = new SqlCommand("SELECT * FROM Pedido WHERE Id = @Id", conexion))
        {
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null; // no existe

            pedido = new Pedido
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                ClienteId = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                ClienteNombre = reader.GetString(reader.GetOrdinal("ClienteNombre")),
                ClienteEmail = reader.GetString(reader.GetOrdinal("ClienteEmail")),
                Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                Estado = Enum.Parse<EstadoPedido>(reader.GetString(reader.GetOrdinal("Estado"))),
                Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                Detalles = new List<DetallePedido>()
            };
        } //acá ya se cierra la consulta para el pedido y para poder luego pedir los detalles, que es lo siguiente

        using (var cmdDet = new SqlCommand("SELECT * FROM DetallePedido WHERE PedidoId = @Id", conexion))
        {
            cmdDet.Parameters.AddWithValue("@Id", id);
            using var r = cmdDet.ExecuteReader();
            while (r.Read())
            {
                pedido.Detalles.Add(new DetallePedido
                {
                    ProductoId = r.GetInt32(r.GetOrdinal("ProductoId")),
                    Producto = r.GetString(r.GetOrdinal("Producto")),
                    Cantidad = r.GetInt32(r.GetOrdinal("Cantidad")),
                    Precio = r.GetDecimal(r.GetOrdinal("Precio"))
                });
            }
        }
        return pedido;
    }

    public void Actualizar(Pedido pedido)
    {
        using var conexion = new SqlConnection(_stringConexion);
        conexion.Open();
        using var cmd = new SqlCommand(
            "UPDATE Pedido SET Estado = @Estado, Total = @Total WHERE Id = @Id", conexion);
        cmd.Parameters.AddWithValue("@Estado", pedido.Estado.ToString());
        cmd.Parameters.AddWithValue("@Total", pedido.Total);
        cmd.Parameters.AddWithValue("@Id", pedido.Id);
        cmd.ExecuteNonQuery();
    }
}
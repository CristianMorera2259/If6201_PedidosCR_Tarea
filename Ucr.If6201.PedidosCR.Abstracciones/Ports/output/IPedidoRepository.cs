using Ucr.If6201.PedidosCR.Dominio.Entities;

namespace Ucr.If6201.PedidosCR.Abstracciones.Ports.output;

public interface IPedidoRepository
{
    void Guardar(Pedido pedido);
    Pedido? ObtenerPorId(int id);
    void Actualizar(Pedido pedido);
}
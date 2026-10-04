using Ucr.If6201.PedidosCR.Abstracciones.Ports.output;
using Ucr.If6201.PedidosCR.Dominio.Entities;

namespace Ucr.If6201.PedidosCR.DA.Memoria;

public class PedidoRepositoryMemoria: IPedidoRepository
{
    public void Guardar(Pedido pedido)
    {
        throw new NotImplementedException();
    }

    public Pedido? ObtenerPorId(int id)
    {
        throw new NotImplementedException();
    }

    public void Actualizar(Pedido pedido)
    {
        throw new NotImplementedException();
    }
}
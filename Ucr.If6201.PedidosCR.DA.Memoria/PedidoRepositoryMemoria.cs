using Ucr.If6201.PedidosCR.Abstracciones.Ports.output;
using Ucr.If6201.PedidosCR.Dominio.Entities;

namespace Ucr.If6201.PedidosCR.DA.Memoria;

public class PedidoRepositoryMemoria : IPedidoRepository
{
    // esto conceptualmente es para ir guardando los pedidos con un id, es llave -> valor y uno busca por id los pedidos
    private readonly Dictionary<int, Pedido> _pedidos = new();

    private int _idIncremental = 1;

    public void Guardar(Pedido pedido)
    {
        pedido.Id = _idIncremental;
        _idIncremental++;
        _pedidos[pedido.Id] = pedido; //se guarda el pedido en el diccionario de pedidos, asignandole el id incremental
    }
    public Pedido? ObtenerPorId(int id)
    {
        return _pedidos.GetValueOrDefault(id); //devuelve ese pedido del diccionario, si no existe lanza excepción
    }

    public void Actualizar(Pedido pedido)
    {
        _pedidos[pedido.Id] = pedido;
    }
}
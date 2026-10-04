using Ucr.If6201.PedidosCR.Abstracciones.dtos;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.input;

namespace Ucr.If6201.PedidosCR.Consola.App;

public class PedidosServices
{
    private readonly ICrearPedido _crearPedido;
    private readonly IConsultarPedido _consultarPedido;
    private readonly ICancelarPedido _cancelarPedido;
    
    public PedidosServices(
        ICrearPedido crearPedido,
        IConsultarPedido consultarPedido,
        ICancelarPedido cancelarPedido)
    {
        _crearPedido = crearPedido;
        _consultarPedido = consultarPedido;
        _cancelarPedido = cancelarPedido;
    }

    public PedidoResponse? CrearPedido(CrearPedidoRequest request)
    {
        try
        {
            return _crearPedido.Ejecutar(request);
        }
        catch (Exception e)
        {
            Console.WriteLine($"""
                          Se incumplió una regla de negocio o hubo un error.
                          Problema: {e.Message}
                          """);
            return null;
        }
    }

    public PedidoResponse? ConsultarPedido(int pedidoId)
    {
        try
        {
            return _consultarPedido.Ejecutar(pedidoId);
        }
        catch (Exception e)
        {
            Console.WriteLine($"""
                           Algo salió mal al consultar el pedido.
                           Problema: {e.Message}
                           """);
            return null;
        }
    }

    public void CancelarPedido(int pedidoId)
    {
        try
        {
            _cancelarPedido.Ejecutar(pedidoId);
        }
        catch (Exception e)
        {
            Console.WriteLine($"""
                           Algo salió mal al cancelar el pedido.
                           Problema: {e.Message}
                           """);
        }
    }


}
using Microsoft.AspNetCore.Mvc;
using Ucr.If6201.PedidosCR.Abstracciones.dtos;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.input;

namespace Ucr.If6201.PedidosCR.Api.Controllers;

[ApiController]
[Route("api/pedidos")]
public class PedidosController : ControllerBase
{
    private readonly ICrearPedido _crearPedido;

    public PedidosController(ICrearPedido crearPedido)
    {
        _crearPedido = crearPedido;
    }

    [HttpPost]
    public IActionResult Crear(
        CrearPedidoRequest request)
    {
        var resultado = _crearPedido.Ejecutar(request);

        return Ok(resultado);
    }
}
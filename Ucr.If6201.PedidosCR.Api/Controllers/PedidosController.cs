using Microsoft.AspNetCore.Mvc;
using Ucr.If6201.PedidosCR.Abstracciones.dtos;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.input;
using Ucr.If6201.PedidosCR.Dominio.Exceptions;

namespace Ucr.If6201.PedidosCR.Api.Controllers;

[ApiController]
[Route("api/pedidos")]
public class PedidosController : ControllerBase
{
    private readonly ICrearPedido _crearPedido;
    private readonly IConsultarPedido _consultarPedido;
    private readonly ICancelarPedido _cancelarPedido;

// Se inyectan únicamente los puertos de entrada (interfaces)

    public PedidosController(ICrearPedido crearPedido, IConsultarPedido consultarPedido,
        ICancelarPedido cancelarPedido)
    {
        _crearPedido = crearPedido;
        _consultarPedido = consultarPedido;
        _cancelarPedido = cancelarPedido;
    }

    [HttpPost]
    public IActionResult Crear([FromBody] CrearPedidoRequest request)
    {
        try
        {
            var resultado = _crearPedido.Ejecutar(request);
            return CreatedAtAction(nameof(Consultar), new { id = resultado.Id }, resultado);
        }
        catch (ReglaNegocioException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult Consultar(int id)
    {
        var resultado = _consultarPedido.Ejecutar(id);
        if (resultado == null)
            return NotFound(new { mensaje = $"Pedido con ID {id} no fue encontrado." });

        return Ok(resultado);
    }

    [HttpPut("{id:int}/cancelar")]
    public IActionResult Cancelar(int id)
    {
        try
        {
            _cancelarPedido.Ejecutar(id);
            return Ok(new { mensaje = $"Pedido #{id} cancelado correctamente." });
        }
        catch (ReglaNegocioException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}

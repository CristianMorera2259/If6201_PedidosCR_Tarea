using Ucr.If6201.PedidosCR.Abstracciones.dtos;

namespace Ucr.If6201.PedidosCR.Consola.App;

// Ok, esto está DESASTROSO, mientras funcione por ahora está bien xd
public class AppMenu
{
    private readonly string AgregarText =
        """
        
        ------------------------------------------
        / Menú principal / Ingreso de Pedido
        Ingreso de Pedido
        Rellene los datos según se vayan pidiendo.
        """;

    private readonly string MainMenuText =
        """
        
        ------------------------------------------
        / Menú principal
        Menú principal
        Ingrese alguna de las siguientes opciones:
        1. Crear Pedido
        2. Consultar Pedido
        3. Cancelar Pedido
        4. Salir
        """;
    
    private readonly string ConsultarText =
        """
        
        ------------------------------------------
        / Menú principal / Consultar
        Menú consultar
        Rellene los datos según se vayan pidiendo.
        """;
    
    private readonly string CancelarText =
        """
        
        ------------------------------------------
        / Menú principal / Cancelar
        Menú Cancelar
        Rellene los datos según se vayan pidiendo.
        """;


    private bool exit = false;

    private readonly PedidosServices _servicios;

    public AppMenu(PedidosServices servicios)
    {
        _servicios = servicios;
    }

    public void MenuPrincipal()
    {
        while (!exit)
        {
            Console.WriteLine(MainMenuText);
            var opcionMenu = obtenerOpcion("Ingrese opción: ", 1, 4);
            switch (opcionMenu)
            {
                case 1:
                    agregarPedido();
                    break;
                case 2:
                    consultarPedido();
                    break;
                case 3:
                    cancelarPedido();
                    break;
                case 4:
                    exit = true;
                    break;
            }
        }
    }

    private void cancelarPedido()
    {
        Console.WriteLine(CancelarText);
        int pedidoId = 0;
        pedidoId = (int) obtenerNumero("Ingrese el id del pedido: ");

        _servicios.CancelarPedido(pedidoId);
        PedidoResponse? response = _servicios.ConsultarPedido(pedidoId);
        if (response != null)
        {
            Console.WriteLine(response.ToString());
            return;
        }
        Console.WriteLine($"No se encontró un pedido con el id {pedidoId}");
    }

    private void consultarPedido()
    {
        Console.WriteLine(ConsultarText);
        int pedidoId = 0;
        pedidoId = (int) obtenerNumero("Ingrese el id del pedido: ");

        PedidoResponse? response = _servicios.ConsultarPedido(pedidoId);
        if (response != null)
        {
            Console.WriteLine("-- Pedido Encontrado --");
            Console.WriteLine(response.ToString());
            Console.WriteLine("--  Fin  Encontrado  --");
            
            return;
        }
        Console.WriteLine($"No se encontró un pedido con el id {pedidoId}");

    }

    private void agregarPedido()
    {
        Console.WriteLine(AgregarText);
        var clienteId = 0;
        var clienteNombre = string.Empty;
        var clienteEmail = string.Empty;

        clienteId = (int)obtenerNumero("Ingrese el Id del cliente: ");
        clienteNombre = obtenerTexto("Ingrese el nombre del cliente: ");
        clienteEmail = obtenerTexto("Ingrese el email del cliente: ");

        var request = new CrearPedidoRequest();
        request.ClienteId = clienteId;
        request.ClienteNombre = clienteNombre;
        request.ClienteEmail = clienteEmail;

        Console.WriteLine("\n-- Vas a ingresar el primer producto.");
        request.Detalles.Add(obtenerDetallePedido());
        while (true)
        {
            Console.WriteLine("""
                              
                              ¿Desea agregar más productos?
                              1- Sí
                              2- No
                              """);

            var opcion = obtenerOpcion("Ingrese opción: ", 1, 2);

            switch (opcion)
            {
                case 1:
                    request.Detalles.Add(obtenerDetallePedido());
                    break;
                case 2:
                    var respuesta = _servicios.CrearPedido(request);
                    if (respuesta != null)
                    {
                        Console.WriteLine(respuesta.ToString());
                    }
                    return;
            }
        }
    }

    private DetallePedidoRequest obtenerDetallePedido()
    {
        var productoId = 0;
        var producto = "";
        var cantidad = 0;
        decimal precio = 0;

        productoId = (int)obtenerNumero("Ingrese el id del producto: ");
        producto = obtenerTexto("Ingrese el nombre del producto: ");
        cantidad = (int)obtenerNumero("Ingrese el cantidad: ");
        precio = obtenerNumero("Ingrese el precio: ");

        var detallePedido = new DetallePedidoRequest();
        detallePedido.ProductoId = productoId;
        detallePedido.Producto = producto;
        detallePedido.Cantidad = cantidad;
        detallePedido.Precio = precio;

        return detallePedido;
    }

    private string obtenerTexto(string mensaje)
    {
        while (true)
        {
            Console.WriteLine("");
            Console.Write(mensaje);
            var entrada = Console.ReadLine();
            if (!string.IsNullOrEmpty(entrada)) return entrada;
            Console.WriteLine("Se ingresó un texto inválido, vuelvelo a intentar");
        }
    }

    private decimal obtenerNumero(string mensaje)
    {
        
        while (true)
        {
            Console.WriteLine("");
            Console.Write(mensaje);
            var entrada = Console.ReadLine();
            if (string.IsNullOrEmpty(entrada))
            {
                Console.WriteLine("Se ingresó un número inválido, vuelvelo a intentar");
                continue;
            }

            decimal numero;
            try
            {
                return Convert.ToDecimal(entrada);
            }
            catch (Exception e)
            {
                Console.WriteLine($"'{entrada}' no es un número válido, intentalo de nuevo.");
                
            }
        }
    }


    private int obtenerOpcion(string texto, int min, int max)
    {
        while (true)
        {
            Console.WriteLine("");
            Console.Write(texto);
            var entrada = Console.ReadLine();

            if (entrada == null)
            {
                Console.Write($"{entrada} es un valor inválido.");
                continue;
            }

            int numero = -1;
            
            try
            {
                numero = Convert.ToInt32(entrada);
                if (min <= numero && numero <= max) return numero;
            }
            catch (Exception e)
            {
                Console.WriteLine($"La entrada '{entrada}' No es un número entre [{min}..{max}]");
                continue;
            }
            
            Console.WriteLine($"El número '{numero}' no está entre las opciones permitidas. [{min}..{max}]");
        }
    }

    private string pedidoResponseToString(PedidoResponse pedidoResponse)
    {
        return $"""
                Id Pedido: {pedidoResponse.Id}
                Id Cliente: {pedidoResponse.ClienteId}
                Nombre Cliente: {pedidoResponse.ClienteNombre}
                Email Cliente: {pedidoResponse.ClienteEmail}
                Fecha: {pedidoResponse.Fecha}
                Estado: {pedidoResponse.Estado}
                Total: {pedidoResponse.Total}
                --- Detalles ---
                {pedidoDetallesToString(pedidoResponse.detalles)}
                """;
    }

    private string pedidoDetallesToString(List<DetallePedidoResponse> pedidoResponseDetalles)
    {
        string finalString = "";
        foreach (var detalle in pedidoResponseDetalles)
        {
            finalString += detalle.ToString();
        }
        
        return finalString;
    }
}
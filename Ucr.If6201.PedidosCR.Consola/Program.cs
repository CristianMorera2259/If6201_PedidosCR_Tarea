using Microsoft.Extensions.DependencyInjection;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.input;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.output;
using Ucr.If6201.PedidosCR.BW.UseCase;
using Ucr.If6201.PedidosCR.Consola.App;
using Ucr.If6201.PedidosCR.DA.Sql;
using Ucr.If6201.PedidosCR.DA.Memoria;
using Ucr.If6201.PedidosCR.Email.SG;


// Acá va lo de inyección de dependencias
var services = new ServiceCollection();
services.AddScoped<ICrearPedido, CrearPedidoUseCase>();
services.AddScoped<IConsultarPedido, ConsultarPedidoUseCase>();
services.AddScoped<ICancelarPedido, CancelarPedidoUseCase>();

/******************************************************************/
/* NOTA: ACÁ ES DONDE SE CONFIGURA SI ES MEMORIA O SI ES SQL */
//var cs = @"Server=localhost\SQLEXPRESS;Database=PedidosCR;Trusted_Connection=True;TrustServerCertificate=True;";
//services.AddScoped<IPedidoRepository>(sp => new PedidoRepositySQL(cs));
services.AddSingleton<IPedidoRepository, PedidoRepositoryMemoria>();
/******************************************************************/

//Se configura y se gestiona la ID para cuando se requieran
services.AddSingleton(new EmailSettings());
services.AddScoped<INotificador, EmailAdapter>();

var serviceProvider = services.BuildServiceProvider();

var crearPedido = serviceProvider.GetRequiredService<ICrearPedido>();
var consultarPedido = serviceProvider.GetRequiredService<IConsultarPedido>();
var cancelarPedido = serviceProvider.GetRequiredService<ICancelarPedido>();



PedidosServices serviciosConsola = new PedidosServices(crearPedido, consultarPedido, cancelarPedido);

AppMenu consola = new AppMenu(serviciosConsola);
consola.MenuPrincipal();

Console.WriteLine("Fin del programa.");

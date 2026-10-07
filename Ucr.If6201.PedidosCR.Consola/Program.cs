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

// Estos se crean nuevos cada que se piden, diay se piden solo una vez :v
services.AddTransient<PedidosServices>();
services.AddTransient<AppMenu>(); // de acá viene la consola

using var serviceProvider = services.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();

// Se obtiene la consola
// Nota: lo hice así para evitar hacer un new en bruto de esto

var consola = scope.ServiceProvider.GetRequiredService<AppMenu>();
consola.MenuPrincipal();

Console.WriteLine("Fin del programa.");

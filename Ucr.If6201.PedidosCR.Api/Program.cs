using Ucr.If6201.PedidosCR.Abstracciones.Ports.input;
using Ucr.If6201.PedidosCR.Abstracciones.Ports.output;
using Ucr.If6201.PedidosCR.BW.UseCase;
using Ucr.If6201.PedidosCR.DA.Sql;
using Ucr.If6201.PedidosCR.DA.Memoria;
using Ucr.If6201.PedidosCR.Email.SG;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



builder.Services.AddScoped<ICrearPedido, CrearPedidoUseCase>();
builder.Services.AddScoped<IConsultarPedido, ConsultarPedidoUseCase>();
builder.Services.AddScoped<ICancelarPedido, CancelarPedidoUseCase>();

/******************************************************************/
/* NOTA: ACÁ ES DONDE SE CONFIGURA SI ES MEMORIA O SI ES SQL */
//var cs = builder.Configuration.GetConnectionString("PedidosCR")!;
//builder.Services.AddScoped<IPedidoRepository>(sp => new PedidoRepositySQL(cs));

builder.Services.AddSingleton<IPedidoRepository, PedidoRepositoryMemoria>();
// (o services.AddSingleton... dependiendo de la variable que uses ahí)
/******************************************************************/

//Se configura y se gestiona la ID para cuando se requieran
builder.Services.AddSingleton(new EmailSettings());
builder.Services.AddScoped<INotificador, EmailAdapter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

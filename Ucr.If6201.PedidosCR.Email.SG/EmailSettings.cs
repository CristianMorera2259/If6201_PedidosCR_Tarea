namespace Ucr.If6201.PedidosCR.Email.SG;

public class EmailSettings {
    //Aquí se guardan los valores por defecto, como el puerto y
    //el servidor que siempre son los mismos, el sender puede cambiar
    //pero para la tarea se puede dejar ese por defecto.
    public string Server {get; set;} = "localhost";
    public int Port {get; set;} = 1025;
    public string Sender {get; set;} = "pedidos@pedidoscr.com";
}
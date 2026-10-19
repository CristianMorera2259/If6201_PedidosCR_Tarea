Ö
C:\Users\crist\Escritorio\TareaInfo\If6201_PedidosCR_Tarea\Ucr.If6201.PedidosCR.Abstracciones\Ports\output\IPedidoRepository.cs
	namespace 	
Ucr
 
. 
If6201 
. 
	PedidosCR 
. 
Abstracciones ,
., -
Ports- 2
.2 3
output3 9
;9 :
public 
	interface 
IPedidoRepository "
{ 
void 
Guardar	 
( 
Pedido 
pedido 
) 
;  
Pedido 

?
 
ObtenerPorId 
( 
int 
id 
)  
;  !
void		 

Actualizar			 
(		 
Pedido		 
pedido		 !
)		! "
;		" #
}

 ¶
zC:\Users\crist\Escritorio\TareaInfo\If6201_PedidosCR_Tarea\Ucr.If6201.PedidosCR.Abstracciones\Ports\output\INotificador.cs
	namespace 	
Ucr
 
. 
If6201 
. 
	PedidosCR 
. 
Abstracciones ,
., -
Ports- 2
.2 3
output3 9
;9 :
public 
	interface 
INotificador 
{ 
void 
Enviar	 
( 
string 
destinatario 
, 
string 
asunto 
, 
string 
mensaje 
) 
; 
}		 á
yC:\Users\crist\Escritorio\TareaInfo\If6201_PedidosCR_Tarea\Ucr.If6201.PedidosCR.Abstracciones\Ports\input\ICrearPedido.cs
	namespace 	
Ucr
 
. 
If6201 
. 
	PedidosCR 
. 
Abstracciones ,
., -
Ports- 2
.2 3
input3 8
;8 9
public 
	interface 
ICrearPedido 
{ 
PedidoResponse 
Ejecutar 
( 
CrearPedidoRequest .
datosCrearPedido/ ?
)? @
;@ A
} á
}C:\Users\crist\Escritorio\TareaInfo\If6201_PedidosCR_Tarea\Ucr.If6201.PedidosCR.Abstracciones\Ports\input\IConsultarPedido.cs
	namespace 	
Ucr
 
. 
If6201 
. 
	PedidosCR 
. 
Abstracciones ,
., -
Ports- 2
.2 3
input3 8
;8 9
public 
	interface 
IConsultarPedido !
{ 
PedidoResponse 
? 
Ejecutar 
( 
int  
pedidoId! )
)) *
;* +
} Æ
|C:\Users\crist\Escritorio\TareaInfo\If6201_PedidosCR_Tarea\Ucr.If6201.PedidosCR.Abstracciones\Ports\input\ICancelarPedido.cs
	namespace 	
Ucr
 
. 
If6201 
. 
	PedidosCR 
. 
Abstracciones ,
., -
Ports- 2
.2 3
input3 8
;8 9
public 
	interface 
ICancelarPedido  
{ 
void 
Ejecutar	 
( 
int 
pedidoId 
) 
;  
} Í
tC:\Users\crist\Escritorio\TareaInfo\If6201_PedidosCR_Tarea\Ucr.If6201.PedidosCR.Abstracciones\dtos\PedidoResponse.cs
	namespace 	
Ucr
 
. 
If6201 
. 
	PedidosCR 
. 
Abstracciones ,
., -
dtos- 1
;1 2
public 
class 
PedidoResponse 
{ 
public 

int 
Id 
{ 
get 
; 
set 
; 
} 
public 

int 
	ClienteId 
{ 
get 
; 
set  #
;# $
}% &
public		 

string		 
ClienteNombre		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
=		. /
string		0 6
.		6 7
Empty		7 <
;		< =
public

 

string

 
ClienteEmail

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
=

- .
string

/ 5
.

5 6
Empty

6 ;
;

; <
public 

DateTime 
Fecha 
{ 
get 
;  
set! $
;$ %
}& '
public 

string 
Estado 
{ 
get 
; 
set  #
;# $
}% &
=' (
string) /
./ 0
Empty0 5
;5 6
public 

double 
Total 
{ 
get 
; 
set "
;" #
}$ %
public 

List 
< !
DetallePedidoResponse %
>% &
detalles' /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
=> ?
new@ C
ListD H
<H I!
DetallePedidoResponseI ^
>^ _
(_ `
)` a
;a b
} ó
{C:\Users\crist\Escritorio\TareaInfo\If6201_PedidosCR_Tarea\Ucr.If6201.PedidosCR.Abstracciones\dtos\DetallePedidoResponse.cs
	namespace 	
Ucr
 
. 
If6201 
. 
	PedidosCR 
. 
Abstracciones ,
., -
dtos- 1
;1 2
public 
class !
DetallePedidoResponse "
{ 
public 

int 

ProductoId 
{ 
get 
;  
set! $
;$ %
}& '
public 

string 
Producto 
{ 
get  
;  !
set" %
;% &
}' (
=) *
string+ 1
.1 2
Empty2 7
;7 8
public 

int 
Cantidad 
{ 
get 
; 
set "
;" #
}$ %
public 

decimal 
Precio 
{ 
get 
;  
set! $
;$ %
}& '
public

 

override

 
string

 
ToString

 #
(

# $
)

$ %
{ 
return 
$"""

$str 
{ 

ProductoId (
}( )
$str) 
{ 
Producto #
}# $
$str$ 
{ 
Cantidad #
}# $
$str$ 
{ 
Precio 
}  
$str 

                """ 
; 
} 
} õ	
zC:\Users\crist\Escritorio\TareaInfo\If6201_PedidosCR_Tarea\Ucr.If6201.PedidosCR.Abstracciones\dtos\DetallePedidoRequest.cs
	namespace 	
Ucr
 
. 
If6201 
. 
	PedidosCR 
. 
Abstracciones ,
., -
dtos- 1
;1 2
public 
class  
DetallePedidoRequest !
{ 
public 

int 

ProductoId 
{ 
get 
;  
set! $
;$ %
}& '
=( )
$num* +
;+ ,
public 

string 
Producto 
{ 
get  
;  !
set" %
;% &
}' (
=) *
string+ 1
.1 2
Empty2 7
;7 8
public 

int 
Cantidad 
{ 
get 
; 
set "
;" #
}$ %
=& '
$num( )
;) *
public 

decimal 
Precio 
{ 
get 
;  
set! $
;$ %
}& '
=( )
$num* +
;+ ,
}

 ü

xC:\Users\crist\Escritorio\TareaInfo\If6201_PedidosCR_Tarea\Ucr.If6201.PedidosCR.Abstracciones\dtos\CrearPedidoRequest.cs
	namespace 	
Ucr
 
. 
If6201 
. 
	PedidosCR 
. 
Abstracciones ,
., -
dtos- 1
;1 2
public 
class 
CrearPedidoRequest 
{ 
public 

int 
	ClienteId 
{ 
get 
; 
set  #
;# $
}% &
=' (
$num) *
;* +
public 

string 
ClienteNombre 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
string0 6
.6 7
Empty7 <
;< =
public 

string 
ClienteEmail 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
public 

List 
<  
DetallePedidoRequest $
>$ %
Detalles& .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
== >
new? B
(B C
)C D
;D E
}

 
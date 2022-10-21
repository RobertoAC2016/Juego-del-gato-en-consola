
//  Vamos a crear el juego del Gato o Ta Te Ti
//  Vamos a necesitar un objeto q me de la posicion, quien es el jugador de esa posicion y el simbolo usado en esa posicion
// Ahora vamos a llenar on objeto lista con las posiciones y un objeto Ubicacion en cada una de ellas
//  Posiciones de la 1 a la 9
List<Ubicacion> pos = new List<Ubicacion>{
    new Ubicacion{ posicion = 1 },
    new Ubicacion{ posicion = 2 },
    new Ubicacion{ posicion = 3 },
    new Ubicacion{ posicion = 4 },
    new Ubicacion{ posicion = 5 },
    new Ubicacion{ posicion = 6 },
    new Ubicacion{ posicion = 7 },
    new Ubicacion{ posicion = 8 },
    new Ubicacion{ posicion = 9 },
};

//   Ahora designamos las variables q contendran el simbolo seleccionado por el jugador 1, simpre empezamos por el 1

String j1simbolo = "";
String j2simbolo = "";
bool ganador = false;   //Esta variable almacenara el indicador que nos dira si ya hubo o no un ganador
int turno = 1;          //  Esta variable indicara el turno actual

Console.WriteLine("Bienvenido a Tic Tac Toc");
Console.Write("Jugador 1, seleccione simbolo ( X o O ): "); //  Aqui le pedimos al usuario que seleccione con que simbolo jugara
j1simbolo = Console.ReadLine().ToUpper();

//  una vez definido el simbolo, le asignaremos el siguiente al otro jugador

j2simbolo = j1simbolo.ToUpper().Equals("X") ? "O" : "X";
Console.WriteLine();
//   Comenzaremos con el ciclo while para usar las 9 jugadas del juego

while (!ganador)    //  Aqui le indicamos que sigamos jugando mientras el ganador sea falso o no haya ganador
{
    Console.Clear();
    Console.WriteLine($"Jugadas restantes : {pos.Where(x => x.simbolo.Equals("")).Count()}");   //  Usamos linq para saber las jugadas restantes
    //  Aqui mostramos los simbolos asignados, como quedaros despues de la asignacion
    Console.WriteLine($"Simbolo  de Jugador 1: {j1simbolo}");
    Console.WriteLine($"Simbolo  de Jugador 2: {j2simbolo}");
    //  ahora vamos a dibujar el tablero
    Console.WriteLine();
    Console.WriteLine($"      |     |     ");
    Console.WriteLine($"   {fn(pos[0])}  |  {fn(pos[1])}  |  {fn(pos[2])}  ");
    Console.WriteLine($"      |     |     ");
    Console.WriteLine($" ─────┼─────┼─────");
    Console.WriteLine($"      |     |     ");
    Console.WriteLine($"   {fn(pos[3])}  |  {fn(pos[4])}  |  {fn(pos[5])}  ");
    Console.WriteLine($"      |     |     ");
    Console.WriteLine($" ─────┼─────┼─────");
    Console.WriteLine($"      |     |     ");
    Console.WriteLine($"   {fn(pos[6])}  |  {fn(pos[7])}  |  {fn(pos[8])}  ");
    Console.WriteLine($"      |     |     ");
    Console.WriteLine();
    //  Ahora mostraremos quien es el jugador en turno
    var valor = turno % 2 == 0 ? 2 : 1;
    //  Ahora pedimos que el jugador en turno selccione un numero de la posicion correspondiente

    Console.Write($"Turno => Jugador {valor}, selecione numero: ");
    var idx = int.Parse(Console.ReadLine());
    //  Aqui debemos evaluar si la posicion seleccionada por el usuario es valida y que no sea una q ya este ocupada
    //  Por lo cual generaremos una validacion mas, en esta validacion no cambiaremos de jugador, se debe mantener el actual
    bool reintento = dame_jugada_valida_o_reintento(pos.Where(x=>x.posicion.Equals(idx)).ToList().FirstOrDefault(), valor, j1simbolo, j2simbolo); //En lugar de false, mandaremos las validaciones a una funcion con los parametros necesarios
    if (!reintento) turno = turno.Equals(1) ? 2 : 1;


    //  Ahora validaremos por cada simbolo si las posiciones seleccionadas por el usuario cumplen para ser ganador

    var simbol = "X";   //empezamos por la X

    for (var x = 0; x < 2; x++)
    {
        //  Las posiciones ganadores son las 9 del tablero y deben ser todas lineales y esta linea debe cruzar 3 simbolos iguales
        //  Veamoslo rapido en excel, haremos 8 filas de las 8 posibles soluciones ganadoras
        //  Ahora tomaremos un objeto Ubicacion para determinar el ganador y lo mostraremos en pantalla
        if (pos[0].simbolo.Equals(simbol) && pos[1].simbolo.Equals(simbol) && pos[2].simbolo.Equals(simbol)) { ganador = true;  Console.WriteLine(); Console.WriteLine($"Jugador ganador : {pos[0].owner}");Console.ReadLine(); break;}
        if (pos[3].simbolo.Equals(simbol) && pos[4].simbolo.Equals(simbol) && pos[5].simbolo.Equals(simbol)) { ganador = true;  Console.WriteLine(); Console.WriteLine($"Jugador ganador : {pos[3].owner}");Console.ReadLine(); break;}
        if (pos[6].simbolo.Equals(simbol) && pos[7].simbolo.Equals(simbol) && pos[8].simbolo.Equals(simbol)) { ganador = true;  Console.WriteLine(); Console.WriteLine($"Jugador ganador : {pos[6].owner}");Console.ReadLine(); break;}
        if (pos[2].simbolo.Equals(simbol) && pos[5].simbolo.Equals(simbol) && pos[8].simbolo.Equals(simbol)) { ganador = true;  Console.WriteLine(); Console.WriteLine($"Jugador ganador : {pos[2].owner}");Console.ReadLine(); break;}
        if (pos[1].simbolo.Equals(simbol) && pos[4].simbolo.Equals(simbol) && pos[7].simbolo.Equals(simbol)) { ganador = true;  Console.WriteLine(); Console.WriteLine($"Jugador ganador : {pos[1].owner}");Console.ReadLine(); break;}
        if (pos[0].simbolo.Equals(simbol) && pos[3].simbolo.Equals(simbol) && pos[6].simbolo.Equals(simbol)) { ganador = true;  Console.WriteLine(); Console.WriteLine($"Jugador ganador : {pos[0].owner}");Console.ReadLine(); break;}
        if (pos[0].simbolo.Equals(simbol) && pos[4].simbolo.Equals(simbol) && pos[8].simbolo.Equals(simbol)) { ganador = true;  Console.WriteLine(); Console.WriteLine($"Jugador ganador : {pos[0].owner}");Console.ReadLine(); break;}
        if (pos[2].simbolo.Equals(simbol) && pos[4].simbolo.Equals(simbol) && pos[6].simbolo.Equals(simbol)) { ganador = true;  Console.WriteLine(); Console.WriteLine($"Jugador ganador : {pos[2].owner}"); Console.ReadLine(); break; }

        simbol = "O";
    }
    //  Ahora, si llega ahaber un ganador, terminara el juego
    //  Pero existe la posibilidad de q no haya ganador y el numero de jugadas tambien se termine
    //  Entonces si no termina el juego y tampoco hay jugadas debemos reiniciar el tablero para que sigan jugando
    if (pos.Where(x=>x.simbolo.Equals("")).ToList().Count <= 0) //  Aqui preguntamos si ya no hay jugadas, reiniciamos
    {
        Console.WriteLine("\nNo hubo un ganador, se reinicia el juego");
        Console.ReadLine();
        pos = new List<Ubicacion>{
            new Ubicacion{ posicion = 1 },
            new Ubicacion{ posicion = 2 },
            new Ubicacion{ posicion = 3 },
            new Ubicacion{ posicion = 4 },
            new Ubicacion{ posicion = 5 },
            new Ubicacion{ posicion = 6 },
            new Ubicacion{ posicion = 7 },
            new Ubicacion{ posicion = 8 },
            new Ubicacion{ posicion = 9 },
        };
        //  Aqui nuevamente creamos nuestra lista de objetos con las ubicaciones limpias
    }
}






bool dame_jugada_valida_o_reintento(Ubicacion? ele, int valor, String j1simbolo, String j2simbolo)
{
    bool reintento = false;
    if (ele != null)    //  valida si es una posicion de 1 o 9
    {
        if (ele.owner.Equals(0))    //  Aqui valido que sea una posicion libre
        {   //  Asignamos los valores del jugador actual en esa posicion
            ele.owner = valor;
            ele.simbolo = valor.Equals(1) ? j1simbolo : j2simbolo;
        }
        else
        {
            Console.WriteLine("Posicion invalida, reintentar jugada, presiona ENTER para continuar");
            Console.ReadLine();
            reintento = true;
        }
    }
    else
    {
        Console.WriteLine("Posicion invalida, reintentar jugada, presiona ENTER para continuar");
        Console.ReadLine();
        reintento = true;
    }
    return reintento;
}







//  Crearemos la funcion


String fn(Ubicacion obj)
{
    return obj.simbolo.Equals("") ? obj.posicion.ToString() : obj.simbolo;
};

//  Crearemos una clase

class Ubicacion
{
    public int posicion { get; set; }
    public int owner { get; set; } = 0;
    public String simbolo { get; set; } = "";
}












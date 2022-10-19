
//  Vamos a ver con LINQ, el uso de la sitaxis de query y la sintaxis de metodos

using System.Linq;

List<Cerveza> beers = new List<Cerveza>{
    new Cerveza { name = "Lager",       brand = "XX",           size = "255ml" },
    new Cerveza { name = "Indio",       brand = "Cuautemoc",    size = "255ml" },
    new Cerveza { name = "Clara",       brand = "Heineken",     size = "255ml" },
    new Cerveza { name = "Tecate",      brand = "Cuautemoc",    size = "255ml" },
    new Cerveza { name = "Especial",    brand = "Modelo",       size = "255ml" },
};
List<Ventas> ventas = new List<Ventas>
{
    new Ventas{ name = "Lager",      quantity = 12},
    new Ventas{ name = "Clara",      quantity = 22},
    new Ventas{ name = "Tecate",     quantity = 32},
    new Ventas{ name = "Indio",      quantity = 42},
    new Ventas{ name = "Especial",   quantity = 55},
};

//  Veamos como podemos mostrar el nombre y la cantidad de la coleccion de ventas

var query = from venta in ventas        //  Aqui selecionamos venta que seria el comodin para seleccionar todos los campos como el * en SQL
            orderby venta.name          //  Aqui ordenamos los datos por el campo name
            select new {                //  Aqui seleccionamos los campos q necesitamos de salida, especificando por valores
                name = venta.name,
                qty = venta.quantity
            };

foreach (var i in query)
    Console.WriteLine($"rows => {i}");
Console.WriteLine();

Console.WriteLine();
//  Hay mas metodos de la sintaxis de linq por metodos
//  Aqui seleccionamos solamente el nombre de la coleccion resultante del query
//  Vamos a modificar el select y regresemos un objeto, no un campo
var qry = query.Select(x => new { x.name , x.qty});

foreach(var i in qry)
    Console.WriteLine($"qry => {i}");
Console.WriteLine();

//   por ultimo veamos como se usa where
//  Aqui seleccionamos solo los registros q empiezan con la letra I mayuscula
var where = query.Where(x => x.name.StartsWith("I"));

foreach (var i in where)
    Console.WriteLine($"where => {i}");
Console.WriteLine();

















Console.WriteLine();
Console.WriteLine();



































//var method = beers.Join(
//    ventas, 
//    v=>v.name, 
//    b=>b.name, 
//    (b, v) => new { 
//        name = b.name, 
//        brand = b.brand, 
//        qty = v.quantity 
//    }
//);

//foreach (var b in method)
//    Console.WriteLine($"beers => {b.name}, {b.brand}, {b.qty}");

//Console.WriteLine();

//Console.WriteLine($"Max => {method.Max(x => x.name)}");


//Console.WriteLine();

//Console.WriteLine($"Min => {method.Min(x => x.name)}");


//Console.WriteLine();

//Console.WriteLine($"First => {method.FirstOrDefault()}");


//Console.WriteLine();

//Console.WriteLine($"Last => {method.LastOrDefault()}");


//Console.WriteLine();

//Console.WriteLine($"Asc => {method.OrderBy(x => x.name).FirstOrDefault()}");


//Console.WriteLine();

//Console.WriteLine($"Desc => {method.OrderByDescending(x => x.name).FirstOrDefault()}");


//Console.WriteLine();

//Console.WriteLine($"Start => {method.Where(x => x.name.StartsWith("I")).FirstOrDefault()}");


//foreach (var b in method.ToList().Skip(0))
//    Console.WriteLine($"Skip => {b}");

















////IEnumerable<string> strEnumerable = new[] { "410", "15", "0", "34", "98", "159", "23", "17", "67", "54", "41", "87" };
////foreach(var e in strEnumerable)
////    Console.WriteLine($"str=>{e}");
////Console.WriteLine();


////IEnumerable<object> objEnumerable = strEnumerable.Cast<object>();
////foreach (var e in objEnumerable)
////    Console.WriteLine($"obj=>{e}");
////Console.WriteLine();


////List<object> objList = new List<object>(strEnumerable.Cast<object>());
////foreach (var e in objList)
////    Console.WriteLine($"List=>{e}");
////Console.WriteLine();


////var oList = strEnumerable.Cast<object>().ToList();
////foreach (var e in oList)
////    Console.WriteLine($"lst=>{e}");




















////Console.WriteLine("\n\n\n\n\n");

////Console.ReadLine();

































































public class Ventas
{
    public String name { get; set; } = "";
    public int quantity { get; set; } = 0;
}
public class Cerveza
{
    public String name { get; set; } = "";
    public String brand { get; set; } = "";
    public String size { get; set; } = "";
}
















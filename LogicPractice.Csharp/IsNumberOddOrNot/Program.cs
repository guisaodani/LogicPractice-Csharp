//NUMERO ES PAR O NO //
using Shared;
using System.Runtime.InteropServices;

var numberStr = string.Empty;
var answer = string.Empty;
do

{
    Console.Write("Ingrese un número entero: ");
    numberStr = Console.ReadLine();
    if (numberStr!.ToLower() == "salir")
    {
        continue;
    }
    var numberInt = 0;

    if (int.TryParse(numberStr, out numberInt))
    {
        if (numberInt % 2 == 0)
        {
            Console.WriteLine($"El numero {numberInt} es par");
        }
        else
        {
            Console.WriteLine($"El numero {numberInt} es impar");
        }
    }
    else { Console.WriteLine($"{numberStr} no es un numero valido."); }

    answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no]?: ", new List<string> { "s", "n" });
} while (answer!.ToLower() == "s");
Console.WriteLine("Fin");
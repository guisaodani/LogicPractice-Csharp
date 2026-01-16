//NUMERO ES PAR O NO //

var numberStr = string.Empty;
do

{
    Console.Write("Ingrese un número entero o 'salir' para salir: ");
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
} while (numberStr!.ToLower() != "salir");
Console.WriteLine("Fin");
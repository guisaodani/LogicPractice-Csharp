//Construir un programa que pida por pantalla 3 números y luego diga cuál es el mayor, el del medio y el menor de los
//números ingresados.

using Shared;

do
{
    Console.WriteLine("Ingrese 3 numero diferentes...\n");
    var a = ConsoleExtension.GetInt("Ingrese el primer numero: ");
    var b = ConsoleExtension.GetInt("Ingrese el segundo numero: ");
    var c = ConsoleExtension.GetInt("Ingrese el tercer numero: ");
    Console.WriteLine("");

    if (a == b || b == c || a == c)
    {
        Console.WriteLine("Ingrese numeros diferentes\n");
        continue;
    }

    if (a > b && a > c)
    {
        if (b > c)
        {
            Console.WriteLine($"El mayor es {a}, el medio es {b}, y el menor es {c}");
        }
        else
        {
            Console.WriteLine($"El mayor es {a}, el medio es {c}, y el menor es {b}");
        }
    }
    else if (b > a & b > c)
    {
        if (a > c)
        {
            Console.WriteLine($"El mayor es {b}, el medio es {a}, el menor es {c}");
        }
        else
        {
            Console.WriteLine($"El mayor es {b}, el medio es {c}, el menor es {a}");
        }
    }
    else
    {
        if (a > b)
        {
            Console.WriteLine($"El mayor es {c}, el medio es {a}, el menor es {b}");
        }
        else
        {
            Console.WriteLine($"El mayor es {c}, el medio es {b}, el menor es {a}");
        }
    }
} while (true);
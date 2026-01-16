//Construir un programa que pida por pantalla 3 números y luego diga cuál es el mayor de los números ingresados.

int a, b, c;
bool valido;

do
{
    Console.Write("INGRESE TRES NUMEROS. \n");

    Console.Write("Ingrese primer numero: ");
    valido = int.TryParse(Console.ReadLine(), out a);

    Console.Write("Ingrese segundo numero: ");
    valido &= int.TryParse(Console.ReadLine(), out b);

    Console.Write("Ingrese tercer numero: ");
    valido &= int.TryParse(Console.ReadLine(), out c);

    if (a == b || a == c || b == c)
    {
        Console.WriteLine("Los números deben ser diferentes.\n");
        continue;
    }

    if (a > b && a > c)
        Console.WriteLine($"El mayor es: {a}");
    else if (b > a && b > c)
        Console.WriteLine($"El mayor es: {b}");
    else
        Console.WriteLine($"El mayor es: {c}");
    break;
} while (true);
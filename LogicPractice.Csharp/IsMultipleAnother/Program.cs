//Construir un programa que pida dos número y diga si el segundo es múltiplo del primero.
using Shared;

do
{
    var a = ConsoleExtension.GetInt("Ingrese primero numero: ");
    var b = ConsoleExtension.GetInt("Ingrese el segundo numero ");

    if (b % a == 0)
    {
        Console.WriteLine($"{b} es multiplo de {a}");
    }
    else
        Console.WriteLine($"{b} no es multiplo de {a}");
}
while (true);
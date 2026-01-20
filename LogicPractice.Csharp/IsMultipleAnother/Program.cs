//Construir un programa que pida dos número y diga si el segundo es múltiplo del primero.
using Shared;

var answer = string.Empty;

var options = new List<string> { "s", "n" };

do
{
    var a = ConsoleExtension.GetInt("Ingrese primero numero: ");
    var b = ConsoleExtension.GetInt("Ingrese el segundo numero ");

    if (b % a == 0)
    {
        Console.WriteLine($"{b} es multiplo de {a}");
    }
    else
    {
        Console.WriteLine($"{b} no es multiplo de {a}");
    }
    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}

while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("FIN");
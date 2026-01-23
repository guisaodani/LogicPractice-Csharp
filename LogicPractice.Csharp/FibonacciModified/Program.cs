using Shared;
using System.Security.Cryptography;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("Cuantos termino quiere (min 3): ");
    double a = 0;
    double b = 1;
    double c = 2;

    Console.Write($"{a,20:N0}{b,20:N0}{c,20:N0}");

    for (int i = 3; i < n; i++)
    {
        double d = a + b + c;
        Console.Write($"{d,20:N0}");
        a = b;
        b = c;
        c = d;
    }
    Console.WriteLine();

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
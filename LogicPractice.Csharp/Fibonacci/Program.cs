using Shared;
using System.Security.Cryptography;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("Cuantos termino quiere: ");
    double a = 0;
    double b = 1;

    Console.Write($"{a}\t{b}\t");

    for (int i = 2; i < n; i++)
    {
        double c = a + b;
        Console.Write($"{c:N0}\t");
        a = b;
        b = c;
    }
    Console.WriteLine();

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
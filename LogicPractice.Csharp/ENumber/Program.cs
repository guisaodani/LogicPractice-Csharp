using Shared;
using System.Security.Cryptography;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("********CALCULO DEL NUMERO e ********");
    var n = ConsoleExtension.GetInt("Cuantos terminos de presición quieres: ");

    var e = CalculateE(n);
    Console.WriteLine($"El valor de 'e' con  {n} terminos, es :{e}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
        Console.WriteLine();
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double CalculateE(int n)
{
    double num = 0;
    for (int i = 0; i < n; i++)
    {
        num += 1 / MyMath.Factorial(i);
    }
    return num;
}
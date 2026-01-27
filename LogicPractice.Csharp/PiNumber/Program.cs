using Shared;
using System.Security.Cryptography;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("********CALCULO DEL NUMERO Pi ********");
    var n = ConsoleExtension.GetInt("Cuantos terminos de presición quieres: ");

    var pi = CalculatePi(n);
    Console.WriteLine($"El valor de 'pi' con  {n} terminos, es :{pi}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
        Console.WriteLine();
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double CalculatePi(int n)
{
    double sum = 0;
    double den = 1;
    int sig = 1;

    for (int i = 0; i < n; i++)
    {
        double ter = 1 / den * sig;
        sum += ter;
        den += 2;
        sig *= -1;
    }
    return sum * 4; ;
}
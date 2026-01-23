using Shared;
using System.Security.Cryptography;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("Ingresa Numero: ");
    var isprime = MyMath.IsPrime(n);
    Console.WriteLine($"El numero: {n} {(isprime ? "SI" : "NO")} es primo");

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
        Console.WriteLine();
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

//bool IsPrime(int n)
//{
//    for (int i = 2; i <= Math.Sqrt(n); i++)
//    {
//        if (n % i == 0) return false;
//    }
//    return true;
//}
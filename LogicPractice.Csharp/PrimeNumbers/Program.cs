using Shared;
using System.Security.Cryptography;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("cuantos numeros primos quieres : ");
    var primes = GetPrimes(n);

    foreach (var prime in primes)
    {
        Console.Write($"{prime,10:N0}");
    }
    Console.WriteLine();
    Console.WriteLine($"La sumatoria es {primes.Sum(),10:N0}");
    Console.WriteLine($"El primedio es {primes.Average(),10:N0}");
    Console.WriteLine();

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
        Console.WriteLine();
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

List<int> GetPrimes(int n)
{
    var primes = new List<int>();
    var num = 2;

    while (primes.Count < n)
    {
        if (MyMath.IsPrime(num))
        {
            primes.Add(num);
        }
        num++;
    }

    return primes;
}
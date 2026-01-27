//Construir un programa que cree un vector N posiciones. llenar con numeros aleatorios
//* i.  Luego debe mostrar la sumatoria y el promedio de los elementos del arreglo.Construir un programa que cree un vector N posiciones. El vector se debe llenar con la siguiente formula Celda[i] = (i + 1)
//* i.  Luego debe mostrar la sumatoria y el promedio de los elementos del arreglo.

using Shared;
using System.Globalization;
using System.Security.Cryptography;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("******** OPERACIONES EN UN ARREGLO ********");
    var n = ConsoleExtension.GetInt("Cuantas Posiciones quiere en el arreglo ? :");
    var numbers = new int[n];

    FillArray(numbers);
    var sum = GetSum(numbers);

    ShowArray(numbers);
    //Console.WriteLine($"La sumatoria es : {sum,30:N2}");
    Console.WriteLine($"La sumatoria es : {numbers.Sum(),30:N2}");
    //Console.WriteLine($"El promerdio es : {sum / n,30:N2}");
    Console.WriteLine($"El promerdio es : {numbers.Average(),30:N2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
        Console.WriteLine();
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double GetSum(int[] numbers)
{
    var sum = 0;
    foreach (var number in numbers)
    {
        sum += number;
    }
    return sum;
}

void ShowArray(int[] numbers)
{
    foreach (var number in numbers)
    {
        Console.Write($"{number,10:N0}");
    }
    Console.WriteLine();
}

void FillArray(int[] numbers)
{
    var random = new Random();
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = random.Next(0, 100);
    }
}
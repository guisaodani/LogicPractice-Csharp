//Construir un programa que cree un vector de N posiciones. Si la posición es par, la celda del vector se debe llenar con la
//siguiente formula Celda[i] = i + 7.  Si la celda es impar, la celda del vector se debe llenar con la siguiente formula Celda[i]
//= i - 1.  Se debe mostrar como quedo el arreglo y luego debe mostrar la sumatoria de las celdas con valores pares y la
//productoria de las celdas con valores impares.
//Construir un programa que cree un vector de N posiciones. Si la posición es par, la celda del vector se debe llenar con la
//siguiente formula Celda[i] = i + 7.  Si la celda es impar, la celda del vector se debe llenar con la siguiente formula Celda[i]
//= i - 1.  Se debe mostrar como quedo el arreglo y luego debe mostrar la sumatoria de las celdas con valores pares y la
//productoria de las celdas con valores impares.

using Shared;
using System.Globalization;
using System.Security.Cryptography;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("******** PARES E IMPARTES EN UN ARRREGLO ********");
    var n = ConsoleExtension.GetInt("Cuantas Posiciones quiere en el arreglo ? :");
    var numbers = new int[n];

    FillArray(numbers);
    var sum = GetSumEven(numbers);
    var prod = GetProdOdd(numbers);

    ShowArray(numbers);
    Console.WriteLine($"La sumatoria es : {sum,30:N0}");
    Console.WriteLine($"La productoria es : {prod,30:N0}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
        Console.WriteLine();
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double GetProdOdd(int[] numbers)
{
    var prod = 1;
    foreach (var number in numbers)
    {
        if (number % 2 != 0)

        {
            prod *= number;
        }
    }
    return prod;
}

int GetSumEven(int[] numbers)
{
    var sum = 0;
    foreach (var number in numbers)
    {
        if (number % 2 == 0)

        {
            sum += number;
        }
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
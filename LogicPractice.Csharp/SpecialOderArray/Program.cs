//Construir un programa que cree un vector de N posiciones. Si la posición es par, la celda del vector se debe llenar con la
//siguiente formula Si la celda es impar, la celda del vector se debe llenar con la siguiente formula
// Luego los elementos que contengan un número par del vector se deben ordenar
//descendentemente en las primeras posiciones del vector y los elementos impares del vector se deben ordenar
//ascendentemente en las últimas posiciones del vector. Se debe mostrar el vector sin ordenar y luego el vector ordenado. Construir un programa que cree un vector de N posiciones. Si la posición es par, la celda del vector se debe llenar con la
//siguiente formula Celda[i] = i * i + 1.  Si la celda es impar, la celda del vector se debe llenar con la siguiente formula
//Celda[i] = 3 * (i + 1).  Luego los elementos que contengan un número par del vector se deben ordenar
//descendentemente en las primeras posiciones del vector y los elementos impares del vector se deben ordenar
//ascendentemente en las últimas posiciones del vector. Se debe mostrar el vector sin ordenar y luego el vector ordenado.

using Shared;
using System;
using System.Globalization;
using System.Security.Cryptography;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("******** ORDENACION ESPECIAL EN UN ARREGLO ********");
    var n = ConsoleExtension.GetInt("Cuantas Posiciones quiere en el arreglo ? :");
    var numbers = new int[n];

    FillArray(numbers);

    Console.WriteLine("Arreglo sin ordenar");
    ShowArray(numbers);
    Console.WriteLine();

    var numbersEven = GetNumbersEven(numbers);
    var numbersOdd = GetNumbersOdd(numbers);
    OrderArray(numbersEven, true);
    OrderArray(numbersOdd);
    Console.WriteLine("Arreglo ordendor");
    ShowArray(numbersEven);
    ShowArray(numbersOdd);

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
        Console.WriteLine();
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

int[] GetNumbersOdd(int[] numbers)
{
    var contOdds = 0;

    foreach (var number in numbers)
    {
        if (!IsEven(number))
        {
            contOdds++;
        }
    }
    var numbersOdd = new int[contOdds];
    var i = 0;

    foreach (var number in numbers)
    {
        if (!IsEven(number))
        {
            numbersOdd[i] = number;
            i++;
        }
    }
    return numbersOdd;
}

int[] GetNumbersEven(int[] numbers)
{
    var contEven = 0;

    foreach (var number in numbers)
    {
        if (IsEven(number))
        {
            contEven++;
        }
    }

    var numbersEven = new int[contEven];
    var i = 0;

    foreach (var number in numbers)
    {
        if (IsEven(number))
        {
            numbersEven[i] = number;
            i++;
        }
    }
    return numbersEven;
}

bool IsEven(int number)
{
    return number % 2 == 0;
}

void OrderArray(int[] numbers, bool idDescending = false)
{
    for (int i = 0; i < numbers.Length - 1; i++)
    {
        for (int j = 0; j < numbers.Length; j++)
        {
            if (idDescending)
            {
                if (numbers[i] < numbers[j])
                {
                    Change(ref numbers[i], ref numbers[j]);
                }
            }
            else
            {
                if (numbers[i] > numbers[j])
                {
                    Change(ref numbers[i], ref numbers[j]);
                }
            }
        }
    }
}

void Change(ref int number1, ref int number2)
{
    int aux = number1;
    number1 = number2;
    number2 = aux;
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
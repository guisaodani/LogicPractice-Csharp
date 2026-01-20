//Construir un programa que pida un año y luego determine si el año es bisiesto o no. Tenga en cuenta que los años
//bisiestos son los números múltiplos de 4, pero que no son múltiplos de 100 y si son múltiplos de 100 y múltiplos de 400
//sí son bisiestos.
using Shared;
using System.Formats.Asn1;

var answer = String.Empty;
var options = new List<string> { "s", "n" };

do
{
    var currentyear = DateTime.Now.Year;
    var message = string.Empty;
    var year = ConsoleExtension.GetInt("Ingrese año: ");

    if (year < currentyear)
    {
        message = "Fue";
    }
    else if (year == currentyear)
    {
        message = "es";
    }
    else
    {
        message = "será";
    }

    if (year % 4 == 0)
    {
        if (year % 100 == 0)
        {
            if (year % 400 == 0)
            {
                Console.WriteLine($"El año: {year}, Si {message} bisiesto");
            }
            else
            {
                Console.WriteLine($"El año: {year}, No {message} bisiesto");
            }
        }
        else
        {
            Console.WriteLine($"El año: {year}, Si {message} bisiesto");
        }
    }
    else
    {
        Console.WriteLine($"El año: {year}, No {message} bisiesto");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ? : ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("FiN");
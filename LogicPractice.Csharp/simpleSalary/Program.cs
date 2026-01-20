//Elaborar un programa que entre el nombre de un empleado, su salario básico por hora y el número de horas trabajadas
//en el mes; escriba su nombre y salario mensual si éste es mayor del salario mínimo, de lo contrario escriba sólo el
//nombre.
using Shared;
using System;

var answer = String.Empty;
var option = new List<string> { "s", "n" };
do
{
    var name = ConsoleExtension.GetString("Ingrese nombre: ");
    var hour = ConsoleExtension.GetFloat("Ingrese numero de horas: ");
    var HourValue = ConsoleExtension.GetDecimal("Ingrese valor hora: ");
    var salaryMinMon = ConsoleExtension.GetDecimal("Ingrese valor del salario minimo mensual: ");

    var salary = (decimal)hour * HourValue;

    if (salary < salaryMinMon)
    {
        Console.WriteLine($"Nombre: {name}");
        Console.WriteLine($"Nombre: {salaryMinMon:C2}");
    }
    else
    {
        Console.WriteLine($"Nombre: {name}");
        Console.WriteLine($"Salary: {salary:C2}");
    }
    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", option);
    } while (!option.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("FIN");
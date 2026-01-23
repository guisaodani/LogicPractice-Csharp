using Shared;
using System.Security.Cryptography;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var a = ConsoleExtension.GetDouble("Ingrese el valor de a :");
    var b = ConsoleExtension.GetDouble("Ingrese el valor de b :");
    var c = ConsoleExtension.GetDouble("Ingrese el valor de c :");

    var solution = QuadraticEquation(a, b, c);
    Console.WriteLine($"x1 = {solution.X1:N5}");
    Console.WriteLine($"x2 = {solution.X2:N5}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

QuadraticEquationSolution QuadraticEquation(double a, double b, double c)
{
    return new QuadraticEquationSolution
    {
        X1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a),
        X2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a)
    };
}

public class QuadraticEquationSolution
{
    public double X1 { get; set; }
    public double X2 { get; set; }
}
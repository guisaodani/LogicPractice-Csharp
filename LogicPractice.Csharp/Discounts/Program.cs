//Un almacén de escritorios hace los siguientes descuentos: si el cliente compra menos de 5 unidades se le da un
//descuento del 10% sobre la compra; si el número de unidades es mayor o igual a cinco pero menos de 10 se le otorga un
//20% y, si son 10 o más se le da un 40%.
//Hacer un programa que determine cuánto debe pagar un cliente si el valor de cada escritorio es de $650.000.

using Shared;

var answer = String.Empty;
var options = new List<string> { "s", "n" };

do

{
    var desk = ConsoleExtension.GetInt("Numero de escritorios: ");
    var ValueToPay = CalculateValue(desk);
    Console.WriteLine($"valor a pagar: {ValueToPay:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ? : ", options);
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}

while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

decimal CalculateValue(int desk)
{
    float discount;

    if (desk < 5)
    {
        discount = 0.1f;
    }
    else if (desk < 10)

    {
        discount = 0.2f;
    }
    else
    {
        discount = 0.4f;
    }

    return desk * 650000M * (decimal)(1 - discount);
}
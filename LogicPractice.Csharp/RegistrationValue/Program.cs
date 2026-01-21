//Se desea obtener el valor de la matrícula de un estudiante cuyo valor se calcula de  la siguiente manera en un subprograma:
//• Si toma 20 o menos créditos, paga el crédito al valor normal.
//• Si toma por encima de 20 créditos, se pagarán los créditos extras al doble de valor normal.
//• Si el estudiante es de estrato 1, 2 o  3  recibe los siguientes  descuentos:
//Si el estrato es 1, el descuento es del 80%.
//Si el estrato es 2, el descuento es del 50%.
//Si el estrato es 3, el descuento es del 30%.
//Además los estratos 1 y 2 reciben subsidio de alimentación y transporte de la siguiente manera (el cual se debe calcular en otro
//subprograma):
//• Para el estrato 1, el subsidio de alimentación y  transporte es  igual a $200.000.
//• Para el estrato 2, el subsidio de alimentación y transporte es igual a $100.000.
//Se debe informar al usuario sobre el costo de la matrícula y el valor del subsidio.

using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var credist = ConsoleExtension.GetInt("Numero de creditos.....................: ");
    var creditValue = ConsoleExtension.GetDecimal("Valor créditos.................: ");
    var stratum = ConsoleExtension.GetInt("Estrato del estudiante.................: ");

    var registrationValue = CalculateRegistration(credist, creditValue, stratum);
    var subsisy = CalculateSubsisy(stratum);

    Console.WriteLine($"Costo de la matricula................:{registrationValue,20:C2}");
    Console.WriteLine($"valor de subsidio....................:{subsisy,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

decimal CalculateSubsisy(int stratum)
{
    if (stratum == 1)
    {
        return 200000m;
    }
    if (stratum == 2)
    {
        return 100000m;
    }
    return 0;
}

decimal CalculateRegistration(int credist, decimal creditValue, int stratum)
{
    decimal value;

    if (credist <= 20)
    {
        value = credist * creditValue;
    }
    else
    {
        value = 20 * creditValue + (credist - 20) * creditValue * 2;
    }

    if (stratum == 1)
    {
        return value * 0.2m;
    }
    if (stratum == 2)
    {
        return value * 0.5m;
    }
    if (stratum == 3)
    {
        return value * 0.7m;
    }

    return value;
}
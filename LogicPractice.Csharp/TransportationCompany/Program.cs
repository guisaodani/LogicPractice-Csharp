using Shared;
using System.Security.Cryptography;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var routeOptions = new List<string> { "1", "2", "3", "4" };
    var route = string.Empty;

    do
    {
        route = ConsoleExtension.GetValidOptions("Ruta [1][2][3][4]...............................:", routeOptions);
    }
    while (!routeOptions.Any(x => x == route));

    var trips = ConsoleExtension.GetInt("Número de viajes................................:");
    var passangers = ConsoleExtension.GetInt("Número de pasajeros total.......................:");
    var packges10 = ConsoleExtension.GetInt("Número de encomiendas de menos de 10Kg..........:");
    var packges10_20 = ConsoleExtension.GetInt("Número de encomiendas entre 10Kg y menos de 20Kg:");
    var packges_20 = ConsoleExtension.GetInt("Número de encomiendas de más de 20Kg............:");

    // caluculos

    var incomePassangers = GetIncomePassangers(route, passangers, trips);
    var incomePackges = GetIcomePackges(route, packges10, packges10_20, packges_20);
    var incomes = incomePassangers + incomePackges;
    var valueHelper = GetValueHelper(incomes);
    var valueAssurrace = GetValueAssurrace(incomes);
    var fuelValue = GetFuelValue(route, trips, passangers, packges10, packges10_20, packges_20);
    var deductions = valueHelper + valueAssurrace + fuelValue;
    var totalToPay = incomes - deductions;

    Console.WriteLine("*******CALCULOS*************");
    Console.WriteLine($"Ingresos por Pasajeros.........................: {incomePassangers,20:C2}");
    Console.WriteLine($"Ingresos por Encomiendas.......................: {incomePackges,20:C2}");
    Console.WriteLine($"                                                  _______________________");
    Console.WriteLine($"TOTAL INGRESOS.................................: {incomes,20:C2}");
    Console.WriteLine($"Pago Ayudante..................................: {valueHelper,20:C2}");
    Console.WriteLine($"Pago Seguro....................................: {valueAssurrace,20:C2}");
    Console.WriteLine($"Pago Combustible...............................: {fuelValue,20:C2}");
    Console.WriteLine($"                                                  _______________________");
    Console.WriteLine($"TOTAL DEDUCCIONES..............................: {deductions,20:C2}");
    Console.WriteLine($"                                                  _______________________");
    Console.WriteLine($"TOTAL A LIQUIDAR...............................: {totalToPay,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

decimal GetFuelValue(string? route, int trips, int passangers, int packges10, int packges10_20, int packges_20)
{
    float kms;

    switch (route)
    {
        case "1":
            kms = 150 * trips;

            break;

        case "2":
            kms = 167 * trips;
            break;

        case "3":
            kms = 183 * trips;
            break;

        default:
            kms = 203 * trips;
            break;
    }

    var gallon = kms / 39;
    var value = (decimal)gallon + 8860m;
    var weitgh = passangers * 60 + packges10 * 10 + packges10_20 * 15 + packges_20 * 20;

    if (weitgh < 5000) return value;
    if (weitgh < 10000) return value * 1.1m;
    return value * 1.25m;
}

decimal GetValueAssurrace(decimal incomes)
{
    if (incomes < 1000000)
    {
        return incomes * 0.03m;
    }

    if (incomes < 2000000)
    {
        return incomes * 0.04m;
    }

    if (incomes < 4000000)
    {
        return incomes * 0.06m;
    }
    return incomes * 0.09m;
}

decimal GetValueHelper(decimal incomes)
{
    if (incomes < 1000000)
    {
        return incomes * 0.05m;
    }

    if (incomes < 2000000)
    {
        return incomes * 0.08m;
    }

    if (incomes < 4000000)
    {
        return incomes * 0.1m;
    }
    return incomes * 0.13m;
}

decimal GetIcomePackges(string? route, int packges10, int packges10_20, int packges_20)
{
    decimal value = 0;

    switch (route)
    {
        case "1":
        case "2":
            if (packges10 < 10) value += packges10 * 100m;
            else if (packges10 < 100) value += packges10 * 102m;
            else if (packges10 < 130) value += packges10 * 150m;
            else value += packges10 * 160m;

            var packgesGreather10 = packges10_20 + packges_20;
            if (packgesGreather10 < 10) value += packgesGreather10 * 120m;
            else if (packgesGreather10 < 100) value += packgesGreather10 * 140m;
            else if (packgesGreather10 < 130) value += packgesGreather10 * 160m;
            else value += packgesGreather10 * 180m;

            return value;

        default:

            if (packges10 < 10) value += packges10 * 130m;
            else if (packges10 < 100) value += packges10 * 160m;
            else if (packges10 < 130) value += packges10 * 175m;
            else value += packges10 * 200m;

            if (packges10_20 < 10) value += packges10_20 * 140m;
            else if (packges10_20 < 100) value += packges10_20 * 180m;
            else if (packges10_20 < 130) value += packges10_20 * 200m;
            else value += packges10_20 * 250m;

            if (packges_20 < 10) value += packges_20 * 170m;
            else if (packges_20 < 100) value += packges_20 * 210m;
            else if (packges_20 < 130) value += packges_20 * 250m;
            else value += packges_20 * 300m;

            return value;
    }
}

decimal GetIncomePassangers(string? route, int passangers, int trips)
{
    decimal value;

    switch (route)
    {
        case "1":
            value = 500000m * trips;
            if (passangers <= 50) return value;
            if (passangers <= 100) return value * 1.05m;
            if (passangers <= 150) return value * 1.06m;
            if (passangers <= 200) return value * 1.07m;
            return value * 1.07m + (passangers - 200) * 50m;

        case "2":
            value = 600000m * trips;
            if (passangers <= 50) return value;
            if (passangers <= 100) return value * 1.07m;
            if (passangers <= 150) return value * 1.08m;
            if (passangers <= 200) return value * 1.09m;
            return value * 1.09m + (passangers - 200) * 60m;

        case "3":
            value = 800000m * trips;
            if (passangers <= 50) return value;
            if (passangers <= 100) return value * 1.1m;
            if (passangers <= 150) return value * 1.13m;
            if (passangers <= 200) return value * 1.15m;
            return value * 1.15m + (passangers - 200) * 100m;

        default:
            value = 1000000m * trips;
            if (passangers <= 50) return value;
            if (passangers <= 100) return value * 1.125m;
            if (passangers <= 150) return value * 1.15m;
            if (passangers <= 200) return value * 1.17m;
            return value * 1.17m + (passangers - 200) * 150m;
    }
}
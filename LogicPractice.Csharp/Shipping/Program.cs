//Una empresa de envío de mercancías, tiene un plan de tarifas y descuentos sobre el valor del envío de mercancía de sus clientes:
//•   Tarifas:
//Si el peso de la mercancía es inferior a 100 kg, la tarifa para el envío de ésta es de 20.000 pesos.
//Si el peso de la mercancía está entre 100 y 150 kg, la tarifa para el envío de ésta es de 25.000 pesos.
//Si el peso de la mercancía es superior a 150 kg y menor o igual a 200 kg, la tarifa para el envío de ésta es de 30.000
//pesos.
//Si el peso de la mercancía es superior a 200 kg, la tarifa es de 35.000 pesos y además por cada 10 kg adicionales se paga
//2.000 pesos.
//•  Descuentos:
//Si el valor de la mercancía está entre 300.000 y 600.000 pesos se hace un descuento del 10% sobre el valor del envío.
//Si el valor de la mercancía es superior a 600.000 pero menor o igual a 1.000.000 de pesos se hace un descuento del 20%
//sobre el valor del envío.
//Si el valor de la mercancía es superior a 1.000.000 se hace un descuento del 30% sobre el valor del envío.
//•  Promociones (solo hay dos tipos de pago):
//Si es día de promoción (lunes) y paga con tarjeta propia del almacén, sólo paga el 50% del costo de envío.
//Si paga en efectivo y el valor de la mercancía es superior a 1.000.000, sólo paga el 60% del costo de envío.
//Si el cliente aplica a una promoción, no puede aplicar a un descuento. Se debe obtener el valor total del envío.

using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var weigth = ConsoleExtension.GetFloat("Peso de la mercacia: ");
    var value = ConsoleExtension.GetDecimal("Valor de la mercancia: ");
    string isMonday;

    do
    {
        isMonday = ConsoleExtension.GetValidOptions("Es Lunes ? S[si], N[no]: ", options)!;
    }
    while (!options.Any(x => x.Equals(isMonday, StringComparison.CurrentCultureIgnoreCase)));

    var payMethods = new List<string> { "e", "t" };
    string payMethod;

    do
    {
        payMethod = ConsoleExtension.GetValidOptions("Tipo pago ? Efectivo[e], Tarjeta[t]", payMethods)!;
    }
    while (!payMethods.Any(x => x.Equals(payMethod, StringComparison.CurrentCultureIgnoreCase)));

    var fare = CalculateValue(weigth);
    var discount = CalculateDiscount(fare, value);
    decimal promotion = 0;

    if (discount == 0)
    {
        promotion = CalculatePromotion(fare, isMonday, payMethod, value);
    }

    Console.WriteLine($"Tarifa ............. {fare,20:C2}");
    Console.WriteLine($"Descuento ...........{discount,20:C2}");
    Console.WriteLine($"Promocion .......... {promotion,20:C2}");
    Console.WriteLine($"Total a pagar .......... {fare - discount - promotion,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("Desea continuar S[si], N[no] ?: ", options);
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

decimal CalculatePromotion(decimal fare, string isMonday, string payMethod, decimal value)
{
    if (isMonday.ToLower() == "s" && payMethod.ToLower() == "t")
    {
        return fare * 0.5m;
    }

    if (payMethod.ToLower() == "e" && value > 1000000m)
    {
        return fare * 0.4m;
    }
    return 0;
}

decimal CalculateDiscount(decimal fare, decimal value)
{
    if (value >= 300000m && value <= 600000m)
    {
        return fare * 0.1m;
    }

    if (value > 600000m && value <= 1000000m)
    {
        return fare * 0.2m;
    }

    if (value >= 1000000m)
    {
        return fare * 0.3m;
    }
    return 0;
}

decimal CalculateValue(float weigth)
{
    if (weigth <= 100)
    {
        return 20000m;
    }
    if (weigth <= 150)
    {
        return 25000m;
    }
    if (weigth <= 200)
    {
        return 30000m; ;
    }
    return 35000m + (int)((weigth - 200) / 10) * 2000m;
}
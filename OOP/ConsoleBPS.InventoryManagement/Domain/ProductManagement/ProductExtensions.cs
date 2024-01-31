using ConsoleBPS.InventoryManagement.Domain.General;

namespace ConsoleBPS.InventoryManagement.Domain.ProductManagement
{
    internal static class ProductExtensions
    {
        static double dollarToEuro = 0.92;
        static double euroToDollar = 1.11;

        static double poundToEuro = 1.14;
        static double euroToPound = 0.88;

        static double dollarToPound = 0.81;
        static double poundToDollar = 1.14;

        public static double ConvertProductPrice(this Product product, Currency targetCurrency)
        {
            Currency sourceCurrency = product.Price.Currency;
            double originalPrice = product.Price.ItemPrice;
            double convertPrice = 0.0;

            if (sourceCurrency == Currency.Dollar && targetCurrency == Currency.Euro)
            {
                convertPrice = originalPrice * dollarToEuro;
            }
            else if (sourceCurrency == Currency.Euro &&  targetCurrency == Currency.Dollar)
            {
                convertPrice = originalPrice * euroToDollar;
            }
            else if (sourceCurrency == Currency.Pound && targetCurrency == Currency.Dollar)
            {
                convertPrice = originalPrice * poundToDollar;
            }
            else if (sourceCurrency == Currency.Pound && targetCurrency == Currency.Euro)
            {
                convertPrice = originalPrice * poundToEuro;
            }
            else if (sourceCurrency == Currency.Euro && targetCurrency == Currency.Pound)
            {
                convertPrice = originalPrice * euroToPound;
            }
            else if (sourceCurrency == Currency.Dollar && targetCurrency == Currency.Pound)
            {
                convertPrice = originalPrice * dollarToPound;
            }

            return convertPrice;
        }
    }
}

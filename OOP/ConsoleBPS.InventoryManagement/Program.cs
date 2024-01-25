using ConsoleBPS.InventoryManagement.Domain.General;
using ConsoleBPS.InventoryManagement.Domain.ProductManagement;

namespace ConsoleBPS.InventoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Price samplePrice = new Price(10, Currency.Euro);
            Product p1 = new Product(1, "Sugar", "Lorem ipsum", samplePrice, UnitType.PerKg, 100);

            p1.IncreaseStock(10);
            p1.Description = "Sample description";

            PrintWelcome();

            #region Layout

            static void PrintWelcome()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@"Bethany's Pie Shop
                                Inventory Management");

                Console.ResetColor();
            }

            #endregion

            Console.WriteLine("Press enter key to start logging in!");
            Console.ReadLine();

            Console.Clear();
        }
    }
}

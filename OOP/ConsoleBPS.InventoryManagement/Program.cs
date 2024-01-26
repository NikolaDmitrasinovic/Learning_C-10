using ConsoleBPS.InventoryManagement.Domain.General;
using ConsoleBPS.InventoryManagement.Domain.ProductManagement;

namespace ConsoleBPS.InventoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product.ChangeStockThreshold(10);
            Product.StockThreshhold = 10;

            //Price samplePrice = new Price(10, Currency.Euro);
            Price samplePrice = new Price() { ItemPrice = 10, Currency = Currency.Euro };

            //Product p1 = new Product(1, "Sugar", "Lorem ipsum", samplePrice, UnitType.PerKg, 100);
            Product p1 = new Product(1) { Name = "Sugar", Description = "Lorem ipsum", Price = samplePrice, UnitType = UnitType.PerKg };

            p1.IncreaseStock(10);
            p1.Description = "Sample description";

            var p2 = new Product(2)
            {
                Name = "Cake decorations", Description = "Lorem ipsum",
                Price = new Price() { ItemPrice = 8, Currency = Currency.Euro }, UnitType = UnitType.PerItem
            };

            p2.Description = "Another description";

            var p3 = new Product(2)
            {
                Name = "Strawberry",
                Description = "Lorem ipsum",
                Price = new Price() { ItemPrice = 3, Currency = Currency.Euro },
                UnitType = UnitType.PerBox
            };

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

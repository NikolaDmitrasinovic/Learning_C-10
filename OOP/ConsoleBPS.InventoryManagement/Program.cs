using BethanysPieShop.InventoryManagement;
using ConsoleBPS.InventoryManagement.Domain.General;
using ConsoleBPS.InventoryManagement.Domain.ProductManagement;

namespace ConsoleBPS.InventoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintWelcome();

            Utilities.InitializeStock();

            Utilities.ShowMainMenu();

            Console.WriteLine("Application shutting down...");

            Console.ReadLine();

            #region Layout

            static void PrintWelcome()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@"Bethany's Pie Shop
                                Inventory Management");

                Console.ResetColor();
            }

            #endregion
        }
    }
}

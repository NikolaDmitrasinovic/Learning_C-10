using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleBPS.InventoryManagement.Domain.General;

namespace ConsoleBPS.InventoryManagement.Domain.ProductManagement
{
    public partial class Product
    {
        public static int StockThreshhold = 5;

        public static void ChangeStockThreshold(int newStatickTreshhold)
        {
            if (newStatickTreshhold > 0)
            {
                StockThreshhold = newStatickTreshhold;
            }
        }

        public void UpdateLowStock()
        {
            if (AmountInStock < 10)
            {
                IsBelowStoctThreshold = true;
            }
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
        }

        private string CreateSimpleProductRepresentation()
        {
            return $"Product {id} ({name})";
        }
    }
}

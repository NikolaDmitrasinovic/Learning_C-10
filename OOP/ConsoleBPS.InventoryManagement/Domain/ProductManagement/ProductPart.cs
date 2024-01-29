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
        public static int StockTreshold = 5;

        public static void ChangeStockThreshold(int newStatickTreshhold)
        {
            if (newStatickTreshhold > 0)
            {
                StockTreshold = newStatickTreshhold;
            }
        }

        public void UpdateLowStock()
        {
            if (AmountInStock < StockTreshold)
            {
                IsBelowStockTreshold = true;
            }
        }

        protected void Log(string message)
        {
            Console.WriteLine(message);
        }

        protected string CreateSimpleProductRepresentation()
        {
            return $"Product {id} ({name})";
        }
    }
}

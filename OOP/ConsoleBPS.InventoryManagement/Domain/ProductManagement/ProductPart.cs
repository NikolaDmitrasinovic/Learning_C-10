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
        private void UpdateLowStock()
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

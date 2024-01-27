using ConsoleBPS.InventoryManagement.Domain.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBPS.InventoryManagement
{
    internal class ProductRepository
    {
        private string directory = @"E:";
        private string productFileName = "products.txt";

        private void CheckForExistingProductFile()
        {
            string path = $"{directory}{productFileName}";

            bool exists = File.Exists(path);
            if (!exists)
            {
                if (Directory.Exists(path))
                    Directory.CreateDirectory(directory);

                using FileStream fs = File.Create(path);
            }
        }

        public List<Product> LoadProductsFromFile()
        {

        }
    }
}

using ConsoleBPS.InventoryManagement.Domain.General;
using ConsoleBPS.InventoryManagement.Domain.ProductManagement;

namespace ConsoleBPS.InventoryManagement
{
    internal class ProductRepository
    {
        private string directory = Directory.GetCurrentDirectory() + @"..\..\..\..\";
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
            List<Product> products = new List<Product>();

            string path = $"{directory}{productFileName}";

            try
            {
                CheckForExistingProductFile();

                string[] productAsString = File.ReadAllLines(path);

                for (int i = 0; i < productAsString.Length; i++)
                {
                    string[] productSplits = productAsString[i].Split(';');

                    bool success = int.TryParse(productSplits[0], out int productId);
                    if (!success)
                        productId = 0;

                    string name = productSplits[1];
                    string description = productSplits[2];

                    success = int.TryParse(productSplits[4], out int itemPrice);
                    if (!success)
                        itemPrice = 0;

                    success = Enum.TryParse(productSplits[5], out Currency currency);
                    if (!success)
                        currency = Currency.Dollar;

                    success = Enum.TryParse(productSplits[6], out UnitType unitType);
                    if (!success)
                        unitType = UnitType.PerItem;

                    success = int.TryParse(productSplits[3], out int maxItemsInStock);
                    if (!success)
                        maxItemsInStock = 100;

                    Product product = new Product(productId, name, description, new Price() { ItemPrice = itemPrice, Currency = currency }, unitType, maxItemsInStock);
                    products.Add(product);
                }
            }
            catch (IndexOutOfRangeException xcp)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(xcp.Message);
            }
            catch (Exception xcp)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(xcp.Message);
            }
            finally
            {
                Console.ResetColor();
            }

            return products;
        }
    }
}

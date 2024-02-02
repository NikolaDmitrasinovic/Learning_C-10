using ConsoleBPS.InventoryManagement.Domain.Contracts;
using ConsoleBPS.InventoryManagement.Domain.General;
using System.Text;
using System.Xml.Linq;

namespace ConsoleBPS.InventoryManagement.Domain.ProductManagement
{
    public class BoxedProduct : Product, ISaveable, ILoggable
    {
        private int amountPerBox;

        public int AmountPerBox
        {
            get { return amountPerBox; }
            set { amountPerBox = value; }
        }

        public BoxedProduct(int Id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock, int amoutPerBox) 
            : base(Id, name, description, price, unitType, maxAmountInStock)
        {
            AmountPerBox = amoutPerBox;
        }

        public override string DisplayDetailsFull(string extraDetails)
        {
            StringBuilder sb = new();

            sb.AppendLine("Boxed Product");

            sb.Append($"{Id} {Name} \n{Description}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockTreshold)
            {
                sb.Append(("\n!!STOCK Low!!"));
            }

            return sb.ToString();
        }

        public override void UseProduct(int items)
        {
            int smallestMultiple = 0;
            int batchSize;

            while (true)
            {
                smallestMultiple++;
                if (smallestMultiple * AmountPerBox > items)
                {
                    batchSize = smallestMultiple * AmountPerBox;
                    break;
                }
            }

            base.UseProduct(batchSize);
        }

        public override void IncreaseStock()
        {
            IncreaseStock(1);

            AmountInStock += AmountPerBox;
        }

        public override void IncreaseStock(int amount)
        {
            int newStock = AmountInStock + amount * AmountPerBox;

            if (newStock <= maxItemsInStock)
            {
                AmountInStock += amount * AmountPerBox;
            }
            else
            {
                AmountInStock = maxItemsInStock;
                Log($"{CreateSimpleProductRepresentation} stock overflow. {newStock - AmountInStock} item(s) ordered that couldn't be stored.");
            }

            if (AmountInStock > 10)
            {
                IsBelowStockTreshold = false;
            }
        }

        public string ConvertToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemsInStock};{Price.ItemPrice};{(int)Price.Currency};{(int)UnitType};1;{AmountPerBox}";
        }

        void ILoggable.Log(string message)
        {
            throw new NotImplementedException();
        }

        public override object Clone()
        {
            return new BoxedProduct(0, Name, Description, new Price() { ItemPrice = Price.ItemPrice, Currency = Price.Currency }, UnitType, maxItemsInStock, AmountInStock);
        }

        //public void UseBoxProduct(int items)
        //{
        //    int smallestMultiple = 0;
        //    int batchSize;

        //    while (true)
        //    {
        //        smallestMultiple++;
        //        if (smallestMultiple * AmountPerBox > items)
        //        {
        //            batchSize = smallestMultiple * AmountPerBox;
        //            break;
        //        }
        //    }

        //    UseProduct(batchSize);
        //}
    }
}

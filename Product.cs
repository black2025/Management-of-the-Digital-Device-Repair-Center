namespace Product.Models
{
    enum PartCategory
    {
        RAM,
        SSD,
        Battery,
        Display,
        Other
    }

    class Product
    {
        public string Name;
        public decimal Price;
        public int Quantity;
        public PartCategory Category;

        public Product(string name, decimal price, int quantity, PartCategory category)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
        }

        public bool IsAvailable
        {
            get
            {
                if (Quantity >= 1)
                {
                    return true;
                }
                else { return false; }
            }
        }

        public decimal GetTotalValue()
        {
            decimal total = Quantity * Price;
            return total;
        }

        public void AddStock(int quantity)
        {
            if (quantity >= 0)
            {
                Quantity += quantity;
                Console.WriteLine("New Quantity Applied Successfully!");
            }
            else
            {
                Console.WriteLine("Failed To Set New Quantity, Check The Value!");
            }
        }

        public void AddStock(int quantity, decimal newPrice)
        {
            if (quantity >= 0 && newPrice >= 0)
            {
                Quantity += quantity;
                Price = newPrice;
                Console.WriteLine("Both Quantity And Price Has Been Set");
            }
            else if ( quantity < 0 || newPrice < 0)
            {
                throw new Exception("The number you entered is lower than 0!");
            }
        }
    }

}

using System.Collections.Generic;

namespace KataPotter.Models.PurchasingSolution
{
    public class Product
    {
        protected internal Product() { }

        public Product(string id, string name, decimal price)
        {
            ProductId = id;
            Name = name;
            Price = price;
        }

        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        //public IEnumerable<Discount> GetApplicableDiscounts { get; internal set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPotter.Models.PurchasingSolution
{
    public class OrderLine
    {
        private IList<Discount> _discounts = new List<Discount>();

        //protected internal OrderLine() { }

        public OrderLine(Order order, Product product, int quantity)
        {
            Order = order;
            Product = product;
            Quantity = quantity;
        }

        public void AddDiscountToOrderLine(Discount discount)
        {
            _discounts.Add(discount);
        }

        public Order Order { get; }
        public Product Product { get; }
        public int Quantity { get; }
        public decimal DiscountedAmount { get; set; }
        public decimal SubTotal => Quantity * Product.Price - DiscountedAmount;
        public IReadOnlyList<Discount> Discounts => _discounts.ToList();
    }
}

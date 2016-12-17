using System;

namespace KataPotter.Models.PurchasingSolution
{
    public abstract class Discount
    {
        protected internal Discount() { }

        public Discount(string name)
        {
            Name = name;
        }

        public Order Order { get; set; }
        public string Name { get; private set; }
        public abstract Order ApplyDiscountToOrder();
        public bool SupercedesOtherDiscounts { get; set; }
        public bool CanBeUsedInJunctionWithOtherDiscounts { get; set; }
    }

    public class PercentageOffDiscount : Discount
    {
        public PercentageOffDiscount(string name, decimal discountPercentage) 
            : base(name)
        {
            DiscountPercentage = discountPercentage;
        }

        public override Order ApplyDiscountToOrder()
        {
            foreach (OrderLine line in Order.OrderLines)
            {
                line.DiscountedAmount = line.Product.Price * DiscountPercentage;
                line.AddDiscountToOrderLine(this);
            }
            return Order;
        }

        public decimal DiscountPercentage { get; private set; }
    }
}
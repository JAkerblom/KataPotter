using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPotter.Models.PurchasingSolution
{
    public class Order
    {
        private IList<OrderLine> _orderLines = new List<OrderLine>();
        private IList<Discount> _discounts = new List<Discount>();

        public Order()
        {

        }

        public OrderLine AddOrderLine(Product product, int quantity)
        {
            OrderLine orderLine = new OrderLine(this, product, quantity);
            _orderLines.Add(orderLine);
            //AddDiscountsOfProduct(product);
            return orderLine;
        }

        public void AddDiscount(Discount discount)
        {
            discount.Order = this;
            discount.ApplyDiscountToOrder();
            _discounts.Add(discount);
        }

        public IList<OrderLine> OrderLines => _orderLines;
        public decimal GrossTotal => _orderLines.Sum(x => x.Product.Price * x.Quantity);
        public decimal NetTotal => _orderLines.Sum(x => x.SubTotal);


        // Maybe to be added when adding item from outside.
        // but preferrably I'd want discount to be added similar to above for each adding of item
        // and calculated right away, instead of adding all in the end. Every item is going
        // to inherit all general and category specific rules in some way, so these doesn't have
        // to come from any other source than the item object itself. I just have to define what
        // type of rule levels I want to be able to support.
        //public void AddApplicableDiscounts()
        //{
        //    foreach (var line in _orderLines)
        //    {
        //        foreach (var discount in line.Product.GetApplicableDiscounts)
        //        {
        //            _discounts.Add(discount);
        //        }
        //    }
        //}

        // Same trial goes for this. We'll se if it will be used.
        //private void AddDiscountsOfProduct(Product product)
        //{
        //    foreach (var discount in product.GetApplicableDiscounts)
        //    {
        //        _discounts.Add(discount);
        //    }
        //}

    }
}

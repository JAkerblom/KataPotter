using System.Collections.Generic;
using KataPotter.Models.Merchandise;

namespace KataPotter.Discount_Rules
{
    public abstract class MultipleDiscountRule : IDiscountRule
    {
        private int AmountOfUniqueItems { get; }
        private decimal Discount { get; }

        public MultipleDiscountRule(int nrOfItems, decimal discount)
        {
            AmountOfUniqueItems = nrOfItems;
            Discount = discount;
        }

        public decimal Calculate(List<List<Item>> items)
        {
            return 0;
        }
    }
}
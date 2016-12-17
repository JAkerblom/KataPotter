using KataPotter.Discount_Rules;
using KataPotter.Models.Merchandise;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class TwoDifferentBooksFromSameSeriesRule : MultipleDiscountRule
    {
        private static int AmountOfBooks => 2;
        private static decimal Discount => 0.05m;
        public bool IsEligible(List<Item> items)
        {
            return items.OfType<Book>().ToList().Count > AmountOfBooks;
        }

        public TwoDifferentBooksFromSameSeriesRule() : base(AmountOfBooks, Discount){}
    }
}
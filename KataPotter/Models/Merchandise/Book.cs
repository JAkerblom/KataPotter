using System.Collections.Generic;
using KataPotter.Discount_Rules;

namespace KataPotter.Models.Merchandise
{
    public class Book : Item
    {

        public string Title { get; }

        public Book(string id, string title, decimal price) 
            : base(id, price, new List<IDiscountRule>()
            {
                new TwoDifferentBooksFromSameSeriesRule()
            })
        {
            Title = title;
        }
    }
}

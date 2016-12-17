using System.Collections.Generic;
using KataPotter.Models.Merchandise;

namespace KataPotter.Discount_Rules
{
    public interface IDiscountRule
    {
        decimal Calculate(List<List<Item>> items);
    }
}
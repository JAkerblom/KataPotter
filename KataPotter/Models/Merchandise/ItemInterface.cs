using KataPotter.Discount_Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPotter.Models.Merchandise
{
    interface ItemInterface
    {
        string Id { get; }
        decimal Price { get; }
        IEnumerable<IDiscountRule> GeneralItemDiscountRules { get; }
        IEnumerable<IDiscountRule> ItemSpecificDiscountRules { get; }
    }
}

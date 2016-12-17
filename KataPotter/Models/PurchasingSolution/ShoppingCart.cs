using System;
using System.Collections.Generic;
using System.Linq;
using KataPotter.Discount_Rules;
using KataPotter.Models.Merchandise;

namespace KataPotter.Models.PurchasingSolution
{
    public class ShoppingCart
    {
        private List<List<Item>> _items { get; }
        private List<IDiscountRule> _discounts { get; }

        public ShoppingCart()
        {
            _items = new List<List<Item>>();
        }

        public IReadOnlyList<Item> Items => _items.SelectMany(x => x).ToList();
        public IReadOnlyList<IReadOnlyList<Item>> GroupedItems => _items.OrderByDescending(x => x.Count).ToList();

        public void AddItem(Item item)
        {
            var sameItemGroup = _items.Find(x => x.FirstOrDefault().Equals(item));
            if (sameItemGroup != null)
                sameItemGroup.Add(item);
            else
            {
                _items.Add(new List<Item>() { item });
                //_discounts.AddRange(item.ItemSpecificDiscountRules);
            }
        }

        public decimal CalculateTotal()
        {
            return Items.Sum(x => x.Price);
        }

        public decimal CalculateDiscount()
        {
            return 0;
        }

        public IEnumerable<IDiscountRule> GetApplicableDiscounts()
        {
            return _discounts.Select(x => x).Distinct();
        }
    }
}
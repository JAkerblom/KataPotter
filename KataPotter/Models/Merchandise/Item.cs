using System;
using System.Collections.Generic;
using KataPotter.Discount_Rules;

namespace KataPotter.Models.Merchandise
{
    public abstract class Item : ItemInterface
    {

        public string Id { get; }
        public decimal Price { get; }
        public IEnumerable<IDiscountRule> GeneralItemDiscountRules { get; }
        public IEnumerable<IDiscountRule> ItemSpecificDiscountRules { get; }

        protected Item(string id, decimal price, List<IDiscountRule> rules)
        {
            Id = id;
            Price = price;
            GeneralItemDiscountRules = new List<IDiscountRule>() { };
            ItemSpecificDiscountRules = rules;
        }

        public override bool Equals(object obj)
        {
            return (obj is Item) && ((Item)obj).Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
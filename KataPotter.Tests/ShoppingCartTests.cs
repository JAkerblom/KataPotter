using System.Linq;
using NUnit.Framework;
using FluentAssertions;
using KataPotter.Models.PurchasingSolution;
using KataPotter.Models.Merchandise;
using System;

namespace KataPotter.Tests
{
    [TestFixture]
    public class When_a_shopping_cart_is_created
    {
        private ShoppingCart _cart;

        [SetUp]
        public void SetUpShoppingCart()
        {
            _cart = new ShoppingCart();
        }

        [Test]
        public void It_should_be_able_to_add_an_item()
        {
            _cart.AddItem(new Book("id1", "Some name", 8));

            _cart.Items.Count.Should().Be(1);
        }

        [Test]
        public void It_should_be_able_to_add_multiple_items()
        {
            _cart.AddItem(new Book("id1", "Some name", 8));
            _cart.AddItem(new Book("id2", "Some name", 8));
            _cart.AddItem(new Book("id3", "Some name", 8));

            _cart.Items.Count.Should().Be(3);
        }

        [Test]
        public void It_should_be_able_to_add_multiple_items_of_same_id()
        {
            _cart.AddItem(new Book("id1", "Some name", 8));
            _cart.AddItem(new Book("id1", "Some name", 8));
            _cart.AddItem(new Book("id1", "Some name", 8));
            _cart.AddItem(new Book("id2", "Some name", 8));
            _cart.AddItem(new Book("id2", "Some name", 8));

            _cart.Items.Count.Should().Be(5);
            _cart.GroupedItems.Count.Should().Be(2);
            _cart.GroupedItems.ElementAt(0).Count.Should().Be(3);
            _cart.GroupedItems.ElementAt(1).Count.Should().Be(2);

        }

        [Test]
        public void It_should_be_able_to_sort_cart_correctly_after_adding_item()
        {
            _cart.AddItem(new Book("id1", "Some name", 8));
            _cart.AddItem(new Book("id1", "Some name", 8));
            _cart.AddItem(new Book("id2", "Some name", 8));
            _cart.AddItem(new Book("id2", "Some name", 8));
            _cart.AddItem(new Book("id2", "Some name", 8));

            _cart.GroupedItems.ElementAt(0).Count.Should().Be(3);
        }

        [Test]
        public void It_should_be_able_to_calc_price_for_one_added_item()
        {
            _cart.AddItem(new Book("id1", "Some name", 8));

            _cart.CalculateTotal().Should().Be(8);
        }

        [Test]
        public void It_should_be_able_to_calc_total_price_excluding_discounts()
        {
            _cart.AddItem(new Book("id1", "Some name", 8));
            _cart.AddItem(new Book("id1", "Some name", 8));
            _cart.AddItem(new Book("id1", "Some name", 8));
            _cart.AddItem(new Book("id2", "Some name", 8));
            _cart.AddItem(new Book("id2", "Some name", 8));

            _cart.CalculateTotal().Should().Be(40);
        }

        [Test]
        public void It_should_be_able_to_calc_discount_for_two_books()
        {
            _cart.AddItem(new Book("id1", "Some name", 8));
            _cart.AddItem(new Book("id2", "Some name", 8));

            _cart.CalculateDiscount().Should().Be(0.8m);
        }

        //[Test]
        //public void It_should_be_able_to_get_applicable_tests()
        //{
        //    _cart.AddItem(new Book("id1", "Some name", 8));

        //    _cart.GetApplicableDiscounts().ElementAt(0).Should().Be(0);
        //}
    }
}

using NUnit.Framework;
using FluentAssertions;
using KataPotter.Models.Merchandise;
using KataPotter.Models.PurchasingSolution;

namespace KataPotter.Tests
{
    [TestFixture]
    public class When_a_shopping_cart_is_used
    {
        private ShoppingCart _cart;

        [SetUp]
        public void SetUpShoppingCart()
        {
            _cart = new ShoppingCart();
        }

        [Test]
        public void It_should_calculate_price_correctly_with_given_book_discount_rules()
        {
            _cart.AddItem(new Book("id1", "Harry Potter and The Sorceror's Stone", 8));
            _cart.AddItem(new Book("id1", "Harry Potter and The Sorceror's Stone", 8));
            _cart.AddItem(new Book("id2", "Harry Potter and The Chamber Of Secrets", 8));
            _cart.AddItem(new Book("id2", "Harry Potter and The Chamber Of Secrets", 8));
            _cart.AddItem(new Book("id3", "Harry Potter and The Prisoner Of Azkaban", 8));
            _cart.AddItem(new Book("id3", "Harry Potter and The Prisoner Of Azkaban", 8));
            _cart.AddItem(new Book("id4", "Harry Potter and The Goblet Of Fire", 8));
            _cart.AddItem(new Book("id5", "Harry Potter and The Order Of The Phoenix", 8));

            _cart.CalculateTotal().Should().Be(51.2m);
        }
    }
}

//new DiscountRule(1, "Two different books from HarryPotter series gives 5% discount on those two books."),
//new DiscountRule(2, "Three different books from HarryPotter series gives 10% discount on those three books."),
//new DiscountRule(3, "Four different books from HarryPotter series gives 20% discount on those four books."),
//new DiscountRule(4, "Five different books from HarryPotter series gives 10% discount on those five books.")

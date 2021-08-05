using CheckoutKata.Domain;
using CheckoutKata.Services;
using CheckoutKata.Test.Mocks;
using System;
using Xunit;

namespace CheckoutKata.Test
{
    public class CheckoutTests
    {
        public IItemRepository GetItemRepository()
        {
            return new ItemRepositoryMock();
        }

        public ICheckout GetCheckoutService()
        {
            return new CheckoutService(GetItemRepository());
        }

        [Fact]
        public void GetItem()
        {
            var repo = GetItemRepository();
            var model = repo.GetItemBySKU("A");

            Assert.NotNull(model);
        }

        [Fact]
        public void GetItemThatDoesntExist()
        {
            var repo = GetItemRepository();
            var model = repo.GetItemBySKU("E");

            Assert.Null(model);
        }

        [Fact]
        public void GetSingleItem()
        {
            var checkout = GetCheckoutService();
            checkout.Scan("D");

            Assert.Equal(checkout.GetTotalPrice(), (int)15);
        }

        [Fact]
        public void GetSingleItemWithSpecial()
        {
            var checkout = GetCheckoutService();
            checkout.Scan("A");

            Assert.Equal(checkout.GetTotalPrice(), (int)50);
        }

        [Fact]
        public void GetSingleItemWithMultipleQuantity()
        {
            var checkout = GetCheckoutService();
            
            checkout.Scan("C");
            checkout.Scan("C");
            checkout.Scan("C");
            checkout.Scan("C");

            Assert.Equal(checkout.GetTotalPrice(), (int)4 * 20);
        }

        [Fact]
        public void GetSingleItemTriggerSpecial()
        {
            var checkout = GetCheckoutService();

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            Assert.Equal(checkout.GetTotalPrice(), (int)130);
        }

        [Fact]
        public void GetSingleItemTriggerSpecialWithExtraQuantity()
        {
            var checkout = GetCheckoutService();

            // special
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            // plus 2 extra
            checkout.Scan("A");
            checkout.Scan("A");

            Assert.Equal(checkout.GetTotalPrice(), (int)130 + 50 + 50);
        }

        [Fact]
        public void GetMultipleItems()
        {
            var checkout = GetCheckoutService();
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");

            Assert.Equal(checkout.GetTotalPrice(), (int)50 + 30 + 20 + 15);
        }

        [Fact]
        public void GetMultipleItemsWithTrigger()
        {
            var checkout = GetCheckoutService();

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            checkout.Scan("B");
            checkout.Scan("B");

            checkout.Scan("C");
            checkout.Scan("D");

            Assert.Equal(checkout.GetTotalPrice(), (int)130 + 45 + 20 + 15);
        }

        [Fact]
        public void GetAllItemsWithEdgeAllCases()
        {
            var checkout = GetCheckoutService();

            for(var i=0; i< 8; i++)
                checkout.Scan("A");

            for (var i = 0; i < 5; i++)
                checkout.Scan("B");

            for (var i = 0; i < 3; i++)
                checkout.Scan("C");

            for (var i = 0; i < 9; i++)
                checkout.Scan("D");

            var total = checkout.GetTotalPrice();
            int actual =
                (130 * 2) + (2 * 50) // for A 2 specials + 2 extras
                + (45 * 2) + 30 // for B 2 specials + 1 extra
                + (3 * 20) // 3 C's
                + (9 * 15); // 9 D's

            Assert.Equal(total, actual);
        }
    }
}

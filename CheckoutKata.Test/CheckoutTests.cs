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
    }
}

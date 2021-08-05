using CheckoutKata.Domain;
using System;

namespace CheckoutKata.Services
{
    public class CheckoutService : ICheckout
    {
        private readonly IItemRepository _itemRepository;

        public CheckoutService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
    }
}

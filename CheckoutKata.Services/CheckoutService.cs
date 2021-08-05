using CheckoutKata.Domain;
using System;
using System.Collections.Generic;

namespace CheckoutKata.Services
{
    public class CheckoutService : ICheckout
    {
        private readonly IItemRepository _itemRepository;
        private Dictionary<string /*sku*/, int /*quantity*/> _items;

        public CheckoutService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
            Init();
        }

        public void Init()
        {
            _items = new Dictionary<string, int>();
        }

        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            var model = _itemRepository.GetItemBySKU(item);

            if (model == null)
                throw new Exception("Item not found");

            if (!_items.ContainsKey(item))
                _items.Add(item, 1);
            else
                _items[item] += 1;
        }
    }
}

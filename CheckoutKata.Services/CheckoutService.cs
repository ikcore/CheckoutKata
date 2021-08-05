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
            int total = 0;

            foreach(var item in _items)
            {                
                var quantity = item.Value;
                var sku = item.Key;
                var model = _itemRepository.GetItemBySKU(sku);

                // handle special cases first
                if (model.SpecialPrice != null)
                {
                    // should quantity/threshold be less than whole int, it will floor to lowest value
                    int numberOfSpecialsTriggered = quantity / model.SpecialPrice.Threshold;
                    int remainderOfItems = quantity % model.SpecialPrice.Threshold;

                    total += numberOfSpecialsTriggered * model.SpecialPrice.UnitPrice;
                    total += remainderOfItems * model.UnitPrice;
                }
                else
                {
                    total += model.UnitPrice * quantity;
                }
            }

            return total;
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

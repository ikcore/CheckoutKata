using CheckoutKata.Domain.Models;

namespace CheckoutKata.Domain
{
    public class ItemModel
    {
        public string SKU { get; set; }
        public int Price { get; set; }
        public ItemSpecialPriceModel SpecialPrice { get; set; }
    }
}

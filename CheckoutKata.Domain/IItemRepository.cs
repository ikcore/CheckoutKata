namespace CheckoutKata.Domain
{
    public interface IItemRepository
    {
        ItemModel GetItemBySKU(string sku);
    }
}

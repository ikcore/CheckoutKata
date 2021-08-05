namespace CheckoutKata.Domain
{
    public interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}

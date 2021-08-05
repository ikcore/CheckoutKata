using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Domain
{
    public interface IItemRepository
    {
        ItemModel GetItemBySKU(string sku);
    }
}

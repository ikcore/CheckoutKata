using CheckoutKata.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Test.Mocks
{
    public class ItemRepositoryMock : IItemRepository
    {
        public readonly Dictionary<string, ItemModel> Items = new Dictionary<string, ItemModel>()
        {
            { "A", new ItemModel()
                {
                    SKU = "A",
                    UnitPrice = 50,
                    SpecialPrice = new Domain.Models.ItemSpecialPriceModel()
                    {
                        Threshold = 3,
                        UnitPrice = 130
                    }
                }
            },
            { "B", new ItemModel()
                {
                    SKU = "B",
                    UnitPrice = 30,
                    SpecialPrice = new Domain.Models.ItemSpecialPriceModel()
                    {
                        Threshold = 2,
                        UnitPrice = 45
                    }
                }
            },
            { "C", new ItemModel()
                {
                    SKU = "C",
                    UnitPrice = 20,
                    SpecialPrice = null
                }
            },
            { "D", new ItemModel()
                {
                    SKU = "D",
                    UnitPrice = 15,
                    SpecialPrice = null
                }
            }
        };

        public ItemModel GetItemBySKU(string sku)
        {            
            return Items.ContainsKey(sku) ? Items[sku] : null;
        }
    }
}

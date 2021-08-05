using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Domain.Models
{
    public class ItemSpecialPriceModel
    {
        public int Threshold { get; set; }
        public int UnitPrice { get; set; }
    }
}

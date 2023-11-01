using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BasketItem
    {
        public Book Book { get; set; }
        public uint Count { get; set; }
        public float DiscountPercent { get; set; }
    }
}

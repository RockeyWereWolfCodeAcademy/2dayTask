using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Basket
    {
        public List<BasketItem> BasketItems {  get; set; }
        public uint TotalCount { get; set; }
        public string DiscountCode { get; set; }
    }
}

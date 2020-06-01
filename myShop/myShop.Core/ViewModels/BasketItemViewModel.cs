using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myShop.Core.ViewModels
{
    public class BasketItemViewModel
    {
        public string Id { get; set; }
        public int Quantitiy { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myShop.Core.Models;

namespace myShop.Core.ViewModels
{
    public class ProductManagerViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<productCategory> ProductCategories { get; set; }
    }
}

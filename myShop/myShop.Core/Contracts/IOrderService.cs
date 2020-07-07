using myShop.Core.Models;
using myShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myShop.Core.Contracts
{
     public interface IOrderService
    {
        void CreatedOrder(Order baseOrder, List<BasketItemViewModel> basketItems);
    }
}

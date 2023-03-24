using BethanysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public readonly IShoppingCart ShoppingCart;
        public readonly decimal ShoppingCartTotal;
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal total)
        {
            this.ShoppingCart = shoppingCart;
            this.ShoppingCartTotal = total;
        }
    }
}

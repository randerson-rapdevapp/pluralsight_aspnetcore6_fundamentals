using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCart _shopppingCart;
        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            this._shopppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shopppingCart.GetShoppingCartItems();
            _shopppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(this._shopppingCart, this._shopppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }
    }
}

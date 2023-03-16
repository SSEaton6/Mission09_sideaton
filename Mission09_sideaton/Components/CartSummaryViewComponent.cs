using Microsoft.AspNetCore.Mvc;
using Mission09_sideaton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sideaton.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private ShoppingCart cart;
        public CartSummaryViewComponent(ShoppingCart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Mission09_sideaton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sideaton.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private ShoppingCart cart { get; set; }
        public PurchaseController (IPurchaseRepository temp, ShoppingCart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }
        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if(cart.Items.Count() == 0)
            {
                ModelState.AddModelError("","Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                purchase.Lines = cart.Items.ToArray();
                repo.SavePurchase(purchase);
                cart.ClearCart();

                return RedirectToPage("/Confirmation");
            }
            else { return View(); }
        }
    }
}

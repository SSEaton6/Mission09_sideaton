using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_sideaton.Infrastructure;
using Mission09_sideaton.Models;

namespace Mission09_sideaton.Pages
{
    public class CartModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public ShoppingCart cart { get; set; }
        public string ReturnUrl { get; set; }
        public CartModel(IBookstoreRepository temp)
        {
            repo = temp;
        }
        //if there is nothing in the cart (like at the beginning of a session) it creates a new cart. 
        // otherwise, it saves the cart so it can be added to and changed later.
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<ShoppingCart>("cart") ?? new ShoppingCart();
        }
        public IActionResult OnPost(int bookId,string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            cart = HttpContext.Session.GetJson<ShoppingCart>("cart") ?? new ShoppingCart();
            cart.AddItem(b, 1);
            HttpContext.Session.SetJson("cart", cart);
            //return url returns user to where they were before
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}

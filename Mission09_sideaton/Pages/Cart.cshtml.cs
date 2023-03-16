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
        public CartModel(IBookstoreRepository temp, ShoppingCart c)
        {
            repo = temp;
            cart = c;
        }
        //if there is nothing in the cart (like at the beginning of a session) it creates a new cart. 
        // otherwise, it saves the cart so it can be added to and changed later.
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(int bookId,string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            cart.AddItem(b, 1);
            //return url returns user to where they were before
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}

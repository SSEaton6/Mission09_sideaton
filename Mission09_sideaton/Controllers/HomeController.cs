using Microsoft.AspNetCore.Mvc;
using Mission09_sideaton.Models;
using Mission09_sideaton.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sideaton.Controllers
{
    public class HomeController : Controller
    {
        //instead of going directly through the context, we use a repository to protect the data.
        private IBookstoreRepository repo;
        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int pageNum = 1)
        {
            //limits the number of books to 10 per page
            int pageSize = 10;

            // using a view model so that multiple things can be returned to the view
            var x = new BooksViewModel
            {
                    Books = repo.Books
                    .OrderBy(b => b.Title)
                    //skips the books for the previous page. makes sure to skip 0 the first time.
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),
                    // creates new instance of pageInfo class
                    PageInfo = new PageInfo
                    { 
                        totalNumBooks = repo.Books.Count(),
                        booksPerPage = pageSize,
                        currentPage = pageNum
                    }

            };
            return View(x);
        }
    }
}

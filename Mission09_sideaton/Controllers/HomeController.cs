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
            int pageSize = 10;

            var x = new BooksViewModel
            {
                    Books = repo.Books
                    .OrderBy(b => b.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),
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

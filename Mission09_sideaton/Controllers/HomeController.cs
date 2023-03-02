using Microsoft.AspNetCore.Mvc;
using Mission09_sideaton.Models;
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
        
        public IActionResult Index()
        {
            var stuff = repo.Books.ToList();
            return View(stuff);
        }
    }
}

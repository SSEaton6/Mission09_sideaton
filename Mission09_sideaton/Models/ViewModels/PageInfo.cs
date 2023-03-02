using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sideaton.Models.ViewModels
{

    //class to hold the page info so that we can paginate throught the books, instead of displaying them all at once
    public class PageInfo
    {
        public int totalNumBooks { get; set; }
        public int booksPerPage { get; set; }
        public int currentPage { get; set; }

        //figure out how many pages we need
        public int totalPages => (int)Math.Ceiling((double) totalNumBooks / booksPerPage);

    }
}

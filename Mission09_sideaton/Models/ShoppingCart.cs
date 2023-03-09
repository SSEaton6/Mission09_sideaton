using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sideaton.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartLineItem> Items { get; set; } = new List<ShoppingCartLineItem>();

        public void AddItem(Book book, int qty)
        {
            ShoppingCartLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new ShoppingCartLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);
            return sum;
        }
    }

    

    public class ShoppingCartLineItem
    { 
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }

}

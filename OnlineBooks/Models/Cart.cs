using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineBooks.Models
{
    public class Cart
    {
        public Cart()
        {
        }

        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem (Books books, int qty)
        {
            CartLine line = Lines
                .Where(b => b.Books.BookId == books.BookId)
                .FirstOrDefault();

            if(line == null)
            {
                Lines.Add(new CartLine
                {
                    Books = books,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Books books) =>
            Lines.RemoveAll(x => x.Books.BookId == books.BookId);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() => Lines.Sum(e => e.Books.Price * e.Quantity);
        
        public class CartLine
        {
            public int CartLineID { get; set; }

            public Books Books { get; set; }

            public int Quantity { get; set; }
        }
    }
}

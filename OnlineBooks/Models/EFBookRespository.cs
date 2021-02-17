using System;
using System.Linq;

namespace OnlineBooks.Models
{
    public class EFBookRespository : IBookRespository
    {
        private OnlineBooksDbContext _context;

        //constructor
        public EFBookRespository(OnlineBooksDbContext context)
        {
            _context = context;
        }

        public IQueryable<Books> Books => _context.Books;
    }
}

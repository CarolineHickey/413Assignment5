using System;
using System.Linq;


//Impliments the iBookRepository class
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

        //Books is being set to the _context.Books
        public IQueryable<Books> Books => _context.Books;
    }
}

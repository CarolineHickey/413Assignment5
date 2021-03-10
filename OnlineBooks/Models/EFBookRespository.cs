using System;
using System.Linq;

//Implimentation class of the iBookRespository.cs
//Sets us up to talk with the database - Intermediary between the database and application
//Impliments the iBookRepository class
//imppliments ibookrepository and OnlineBooksDbContext
namespace OnlineBooks.Models
{
    //inherits from the IBookRespository class that sets Books as a queryable
    //EF = EntityFramework
    public class EFBookRespository : IBookRespository
    {
        private OnlineBooksDbContext _context;

        //constructor --> when we create an EFBookRespository we receive a DbContext
        public EFBookRespository(OnlineBooksDbContext context)
        {
            _context = context;
        }

        //Books is being set to the _context.Books which is the DBset of Books in the dbcontext class
        public IQueryable<Books> Books => _context.Books;
    }
}

using System;
using Microsoft.EntityFrameworkCore;

namespace OnlineBooks.Models
{
    //inheriting from DbContext
    //CRUD is happening within the context class
    public class OnlineBooksDbContext : DbContext
    {
        //constructor, <> in those diamonds is the type, inherits from base
       public OnlineBooksDbContext (DbContextOptions<OnlineBooksDbContext> options) : base (options)
        {

        }

        //return a set of Book ojects
        public DbSet<Books> Books { get; set; }
    }
}

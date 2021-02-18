using System;
using Microsoft.EntityFrameworkCore;

namespace OnlineBooks.Models
{
    //inheriting from DbContext, This is apart of the EntityFramworkCore
    //DvContext represent instances of your entities/ session with the database
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

using System;
using Microsoft.EntityFrameworkCore;

namespace OnlineBooks.Models
{
    //Entity Framework accesses the Database through the context class
    //inheriting from DbContext, This is apart of the EntityFramworkCore
    //DbContext represent instances of your entities/ session with the database
    //CRUD is happening within the context class - information about the session and the database
    //Sets up talking to the Database
    public class OnlineBooksDbContext : DbContext
    {
        //constructor, <> in those diamonds is the type, inherits from base
        //Constructor don't have return anything and hence do not have to put void
       public OnlineBooksDbContext (DbContextOptions<OnlineBooksDbContext> options) : base (options)
        { 

        }

        //return a set of Book ojects
        public DbSet<Books> Books { get; set; }
    }
}

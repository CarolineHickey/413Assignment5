using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//IN THIS CLASS WE ARE SEEDING THE DATABASE BY CREATING NEW INSTANCES OF THE BOOKS OBJECTS.
namespace OnlineBooks.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            OnlineBooksDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<OnlineBooksDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Books.Any())
            {
                context.Books.AddRange(

                    new Books
                    {
                        Title = "Les Miserables",
                        FirstName = "Victor",
                        LastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Category = "Fiction",
                        Genre = "Classic",
                        Price = 9.95M,
                        Pages = 1488
                    },

                    new Books
                    {
                        Title = "Team of Rivals",
                        FirstName = "Doris Kearns",
                        LastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Category = "Non-Fiction",
                        Genre = "Biography",
                        Price = 14.58M,
                        Pages = 944
                    },

                    new Books
                    {
                        Title = "The Snowball",
                        FirstName = "Alice",
                        LastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0451419439",
                        Category = "Non-Fiction",
                        Genre = "Biography",
                        Price = 21.54M,
                        Pages = 832
                    },

                    new Books
                    {
                        Title = "American Ulysses",
                        FirstName = "Ronald C.",
                        LastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254 ",
                        Category = "Non-Fiction",
                        Genre = "Biography",
                        Price = 11.61M,
                        Pages = 864
                    },

                    new Books
                    {
                        Title = "Unbroken",
                        FirstName = "Laura",
                        LastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Category = "Non-Fiction",
                        Genre = "Historical",
                        Price = 13.33M,
                        Pages = 528
                    },

                    new Books
                    {
                        Title = "The Great Train Robbery",
                        FirstName = "Michael",
                        LastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Category = "Fiction",
                        Genre = "Historical Fiction",
                        Price = 15.95M,
                        Pages = 288
                    },

                    new Books
                    {
                        Title = "Deep Work",
                        FirstName = "CaL",
                        LastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Category = "Non-Fiction",
                        Genre  = "Self-Help",
                        Price = 14.99M,
                        Pages = 304
                    },

                    new Books
                    {
                        Title = "It's Your Ship",
                        FirstName = "Michael",
                        LastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Category = "Non-Fiction",
                        Genre = "Self-Help",
                        Price = 21.66M,
                        Pages = 240
                    },

                    new Books
                    {
                        Title = "The Virgin Way",
                        FirstName = "Richard",
                        LastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Category = "Non-Fiction",
                        Genre = "Business",
                        Price = 29.16M,
                        Pages = 400
                    },

                    new Books
                    {
                        Title = "Sycamore Row",
                        FirstName = "John",
                        LastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Category = "Fiction",
                        Genre = "Thrillers", 
                        Price = 15.03M,
                        Pages = 642
                    },

                    new Books
                    {
                        Title = "Pride and Prejudice",
                        FirstName = "Jane",
                        LastName = "Austen",
                        Publisher = "Thomas Egerton",
                        ISBN = "978-1503290563",
                        Category = "Romance",
                        Genre = "Fiction",
                        Price = 9.45M,
                        Pages = 284
                    },

                    new Books
                    {
                        Title = "The Help",
                        FirstName = "Kathryn",
                        LastName = "Stockett",
                        Publisher = "Berkley",
                        ISBN = "978-0425232200",
                        Category = "Historical",
                        Genre = "Fiction",
                        Price = 14.56M,
                        Pages = 524
                    },

                    new Books
                    {
                        Title = "To Kill a Mocking Bird",
                        FirstName = "Harper",
                        LastName = "Lee",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-0446310789",
                        Category = "Historical",
                        Genre = "Fiction",
                        Price = 18.99M,
                        Pages = 281
                    }
                    

                ) ;

                context.SaveChanges();
            }
        }
    }
}

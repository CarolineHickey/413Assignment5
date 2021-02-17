using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
                        FristName = "Victor",
                        LastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Category = "Fiction",
                        Genre = "Classic",
                        Price = "$9.95"
                    },

                    new Books
                    {
                        Title = "Team of Rivals",
                        FristName = "Doris Kearns",
                        LastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Category = "Non-Fiction",
                        Genre = "Biography",
                        Price = "$14.58"
                    },

                    new Books
                    {
                        Title = "The Snowball",
                        FristName = "Alice",
                        LastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0451419439",
                        Category = "Non-Fiction",
                        Genre = "Biography",
                        Price = "$21.54"
                    },

                    new Books
                    {
                        Title = "American Ulysses",
                        FristName = "Ronald C.",
                        LastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254 ",
                        Category = "Non-Fiction",
                        Genre = "Biography",
                        Price = "$11.61"
                    },

                    new Books
                    {
                        Title = "Unbroken",
                        FristName = "Laura",
                        LastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Category = "Non-Fiction",
                        Genre = "Historical",
                        Price = "$13.33"
                    },

                    new Books
                    {
                        Title = "The Great Train Robbery",
                        FristName = "Michael",
                        LastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Category = "Fiction",
                        Genre = "Historical Fiction",
                        Price = "$15.95",
                    },

                    new Books
                    {
                        Title = "Deep Work",
                        FristName = "CaL",
                        LastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Category = "Non-Fiction",
                        Genre  = "Self-Help",
                        Price = "$14.99",
                    },

                    new Books
                    {
                        Title = "It's Your Ship",
                        FristName = "Michael",
                        LastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Category = "Non-Fiction",
                        Genre = "Self-Help",
                        Price = "$21.66",
                    },

                    new Books
                    {
                        Title = "The Virgin Way",
                        FristName = "Richard",
                        LastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Category = "Non-Fiction",
                        Genre = "Business",
                        Price = "$29.16",
                    },

                    new Books
                    {
                        Title = "Sycamore Row",
                        FristName = "John",
                        LastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Category = "Fiction",
                        Genre = "Thrillers", 
                        Price = "$15.03",
                    }

                ) ;

                context.SaveChanges();
            }
        }
    }
}

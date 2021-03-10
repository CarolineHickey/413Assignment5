using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBooks.Infrastructure;
using OnlineBooks.Models;

namespace OnlineBooks.Pages
{
    public class CartModel : PageModel
    {
        private IBookRespository repository;


        //Constructor
        public CartModel(IBookRespository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //I COMMENTTED THIS OUT FYI
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Books books = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            //I COMMENTED THIS OUT
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(books, 1);

            //I COMMENTED THIS OUT
            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Books.BookId == bookId).Books);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}

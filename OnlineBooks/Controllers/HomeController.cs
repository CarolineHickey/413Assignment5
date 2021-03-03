using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBooks.Models;
using OnlineBooks.Models.ViewModels;

namespace OnlineBooks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookRespository _respository;

        public int PageSize = 5; //This way the page will only allow 5 items per page

        //controller
        public HomeController(ILogger<HomeController> logger, IBookRespository respository)
        {
            _logger = logger;
            _respository = respository;
        }

        //When the Index page is called, we will pass in all the info neccesary to build the pagination on the fly!
        public IActionResult Index(string category, int page = 1) //a Query!! in a language called linq!
        {
            return View(new BookListViewModel
            {
                Books = _respository.Books

                //This gets us the right data when selecting a certain category
                .Where(p => category == null || p.Category == category)
                .OrderBy(b => b.BookId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,

                    //figure out how many pages to display at the bottom for our pagination. 
                    TotalNumItems =  category == null ? _respository.Books.Count() :
                    _respository.Books.Where(x => x.Category == category).Count()
                },

                CurrentCategory = category

            }) ; 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

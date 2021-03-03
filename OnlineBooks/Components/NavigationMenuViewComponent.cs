using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using OnlineBooks.Models;

namespace OnlineBooks.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {

        private IBookRespository repository;

        public NavigationMenuViewComponent(IBookRespository repo)
        {
            repository = repo;
        }

        //This is a partial view. This will be dropped into the spot designated
        //This will be only a partial view
        public IViewComponentResult Invoke()
        {
            //Go to your URL and find what category is there
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            //Go and pull all the info according to the
            //SQL type statement
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}

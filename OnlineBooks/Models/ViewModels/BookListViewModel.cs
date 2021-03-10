using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models.ViewModels
{
    //This creates an enumerable of Book objects AND PaginingInfo objects!!
    public class BookListViewModel
    {
        //Book objects
        public IEnumerable<Books> Books { get; set; }

        //PagingInfo objects
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}

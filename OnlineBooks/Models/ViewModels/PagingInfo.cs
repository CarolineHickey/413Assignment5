using System;
namespace OnlineBooks.Models.ViewModels
{
    public class PagingInfo
    {
        //Gather-set all the paging info needed to build the pagination
        public int TotalNumItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)(Math.Ceiling((decimal)TotalNumItems / ItemsPerPage));
    }
}

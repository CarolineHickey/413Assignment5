using System;
using System.Linq;

//This is a template that will be inherited from - INTERFACES are meant to be inherited from 
//consitant access to the data from the context class - Widely used
namespace OnlineBooks.Models
{
    public interface IBookRespository
    {
        //This makes it easier to query out the info we want
        IQueryable<Books> Books { get; }
    }
}

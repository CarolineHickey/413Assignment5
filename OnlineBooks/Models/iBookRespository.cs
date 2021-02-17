using System;
using System.Linq;

namespace OnlineBooks.Models
{
    public interface IBookRespository
    {
        IQueryable<Books> Books { get; }
    }
}

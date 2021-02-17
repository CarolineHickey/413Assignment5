using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineBooks.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Price { get; set; }
    }
}

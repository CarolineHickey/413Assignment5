﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineBooks.Models
{
    public class Books
    {
           //All the attributes stored for each Book
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        //[RegularExpression(@"^\(?\d{3}?\)??-??\(?\d{9}?\)??-?$")]
        [RegularExpression(@"^\d{3}-{1}\d{10}$")]
        public string ISBN { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Pages { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Rate { get; set; }
        public decimal Price { get; set; }

    }
}
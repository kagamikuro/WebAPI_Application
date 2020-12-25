using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;

namespace WebAPIApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Rate { get; set; }
        public decimal Price { get; set; }

        public Book(int Id,string Name, String Type, int Rate, decimal price)
        {
            this.Id = Id;
            this.Name = Name;
            this.Type = Type;
            this.Rate = Rate;
            this.Price = price;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ajax.Models
{
    public class Product
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }
        public ICollection<Sale> sales { get; set; }
    }
    public class Sale
    {

        public int Id { get; set; }

        public string qty { get; set; }

        public Product product { get; set; }
    }
}
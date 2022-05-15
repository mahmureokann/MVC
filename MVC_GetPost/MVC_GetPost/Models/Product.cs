using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_GetPost.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string CategoryName { get; set; }
    }
}
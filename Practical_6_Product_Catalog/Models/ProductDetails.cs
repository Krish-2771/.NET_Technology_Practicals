using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P6_Product_Catalog.Models
{
    public class ProductDetails
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
    }
}
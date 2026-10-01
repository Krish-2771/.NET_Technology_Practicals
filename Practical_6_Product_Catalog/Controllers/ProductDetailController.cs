using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using P6_Product_Catalog.Models;

namespace P6_Product_Catalog.Controllers
{
    public class ProductDetailController : Controller
    {
        // Product Catalog Page
        public ActionResult Index()
        {
            List<ProductDetails> P = GetProductData();

            return View(P);
        }

        // Product Detail Page
        public ActionResult ProductDetail(int id)
        {
            List<ProductDetails> P = GetProductData();

            ProductDetails product = P.FirstOrDefault(x => x.ProductId == id);

            return View("ProductDetail", product);
        }

        public List<ProductDetails> GetProductData()
        {
            List<ProductDetails> P = new List<ProductDetails>();

            ProductDetails p1 = new ProductDetails();
            p1.ProductId = 1001;
            p1.ProductName = "Laptop";
            p1.ProductCategory = "Electronics";
            p1.ProductPrice = 69999.00m;
            p1.ProductImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqdpsYCh07Y2VPGd3Rwb4rgnldqEskT_gk5Ay0eI1Htw&s=10";

            P.Add(p1);

            ProductDetails p2 = new ProductDetails();
            p2.ProductId = 1002;
            p2.ProductName = "Mobile";
            p2.ProductCategory = "Electronics";
            p2.ProductPrice = 169999.00m;
            p2.ProductImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSmaGLt9N6Ev7XsEsMV6Hz0Czp8EzPsBv7oH5qU2HPetw&s=10";

            P.Add(p2);

            ProductDetails p3 = new ProductDetails();
            p3.ProductId = 1003;
            p3.ProductName = "Smart Watch";
            p3.ProductCategory = "Electronics";
            p3.ProductPrice = 9999.00m;
            p3.ProductImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ4VrvkzPz_Thx8VBNMmvUEaJbgWbAOO8ljNMFmu2E1sPhD4AK3ebYarRwe&s=10";

            P.Add(p3);

            return P;
        }
    }
}
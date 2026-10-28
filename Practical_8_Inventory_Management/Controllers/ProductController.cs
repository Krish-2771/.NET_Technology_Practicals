using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practical_8.Models;

namespace Practical_8.Controllers
{
    public class ProductController : Controller
    {
        string cs = "Data Source=localhost;Initial Catalog=Product;Integrated Security=True;TrustServerCertificate=True";
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();

            using( SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT * FROM Products";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    products.Add(new Product
                    {
                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        ProductName = dr["ProductName"].ToString(),
                        Quantity = Convert.ToInt32(dr["Quantity"]),
                        Price = Convert.ToDecimal(dr["Price"])
                    });
                }   
            }

            return View(products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (!ModelState.IsValid) return View(p);

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "INSERT INTO Products (ProductName, Quantity, Price) " +
                               "VALUES (@Name, @Qty, @Price)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", p.ProductName);
                cmd.Parameters.AddWithValue("@Qty", p.Quantity);
                cmd.Parameters.AddWithValue("@Price", p.Price);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Product p = null;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT ProductId, ProductName, Quantity, Price " +
                               "FROM Products WHERE ProductId = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        p = new Product
                        {
                            ProductId = Convert.ToInt32(dr["ProductId"]),
                            ProductName = dr["ProductName"].ToString(),
                            Quantity = Convert.ToInt32(dr["Quantity"]),
                            Price = Convert.ToDecimal(dr["Price"])
                        };
                    }
                }
            }

            if (p == null) return HttpNotFound();
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (!ModelState.IsValid) return View(p);

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "UPDATE Products SET ProductName = @Name, " +
                               "Quantity = @Qty, Price = @Price WHERE ProductId = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", p.ProductId);
                cmd.Parameters.AddWithValue("@Name", p.ProductName);
                cmd.Parameters.AddWithValue("@Qty", p.Quantity);
                cmd.Parameters.AddWithValue("@Price", p.Price);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");   
        }

        public ActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductId = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }

}
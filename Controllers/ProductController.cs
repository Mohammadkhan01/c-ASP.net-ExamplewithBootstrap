using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Config;
using WebApplication1.Models;
using WebApplication1.ViewModel;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private StoreContext store;

        public ProductController()
        {
            store = new StoreContext();
        }
        public ActionResult Create()
        {
            var categories = store.Categories.ToList();
            var viewModel = new ProductFromViewModel
            {
                Product = new Product(),
                Categories = categories
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View("Create", store);

            if (product.Id > 0)
                store.Entry(product).State = System.Data.Entity.EntityState.Modified;
            else
                store.Products.Add(product);
            store.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var product = store.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();
            var viewModel = new ProductFromViewModel
            {
                Product = product,
                Categories = store.Categories.ToList()
            };
            return View("Create", viewModel);
        }

        public ActionResult Index()
        {
            //Eagar Loading
            var products = store.Products.Include(c => c.Category ).ToList();
            return View(products);
        }
    }
        //    // GET: Product
        //    public ActionResult Create()
        //    {
        //        return View(new Product { Id = 0 });
        //    }

        //    [HttpPost]
        //    public ActionResult Create(Product product)
        //    {   //string insertSQL= "Insert into Products(Name,Price,Supplier) Values('" + product.Name + "','" + product.Price + "','" + product.Supplier + "')";
        //        //string updateSQL = "Update Products Set Name='" + product.Name + "', Price= '" + product.Price + "',Supplier = '" + product.Supplier + "' where Id = '" + product.Id + "' ";
        //        if (ModelState.IsValid)
        //        {


        //            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
        //            {
        //                //  using (SqlCommand cmd = new SqlCommand((product.Id > 0) ? updateSQL : insertSQL, con))
        //                using (SqlCommand cmd = new SqlCommand("Products_SaveOrUpdate", con))
        //                {

        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.AddWithValue("@Id", product.Id);
        //                    cmd.Parameters.AddWithValue("@Name", product.Name);
        //                    cmd.Parameters.AddWithValue("@Price", product.Price);
        //                    cmd.Parameters.AddWithValue("@Supplier", product.Supplier);


        //                    if (con.State != System.Data.ConnectionState.Open)
        //                        con.Open();
        //                    cmd.ExecuteNonQuery();
        //                }
        //            }
        //            return RedirectToAction("GetAll");
        //        }
        //        return View("Create", product);
        //    }

        //    public ActionResult Search(string search)
        //    {
        //        List<Product> products = GetProducts("Products_SearchProduct", "search");
        //            return View("GetAll", products);
        //    }

        //    public List<Product> GetProducts(string storeProcedure, string search)
        //    {
        //        List<Product> products = new List<Product>();
        //        using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(storeProcedure, con))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                if (search != null)
        //                {
        //                    cmd.Parameters.AddWithValue("@Filter", search);
        //                }

        //                if (con.State != System.Data.ConnectionState.Open)
        //                    con.Open();
        //                SqlDataReader sdr = cmd.ExecuteReader();
        //                DataTable dtProducts = new DataTable();
        //                dtProducts.Load(sdr);
        //                foreach (DataRow row in dtProducts.Rows)
        //                {
        //                    products.Add
        //                        (
        //                            new Product
        //                            {
        //                                Id = Convert.ToInt32(row["Id"]),
        //                                Name = row["Name"].ToString(),
        //                                Price = Convert.ToDouble(row["Price"]),
        //                                Supplier = row["Supplier"].ToString()
        //                            }
        //                        );
        //                }

        //            }
        //            return products;
        //        }

        //    }
        //    public ActionResult GetAll()
        //    {
        //        List<Product> products = GetProducts("Products_GetAllProducts", null);
        //        return View(products);

        //    }

        //    public ActionResult Delete(int Id)
        //    {
        //        if (Id < 1)
        //            return HttpNotFound();
        //        using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("Product_DeleteById", con))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@Id",Id);
        //                if (con.State != System.Data.ConnectionState.Open)
        //                    con.Open();
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //        return RedirectToAction("GetAll");
        //    }

        //    public ActionResult Edit(int Id)
        //    {
        //        if (Id < 1)
        //            return HttpNotFound();
        //        var product = new Product();
        //        using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("Product_GetById", con))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.Add("@Id", Id);
        //                if (con.State != System.Data.ConnectionState.Open)
        //                    con.Open();

        //                SqlDataReader sdr = cmd.ExecuteReader();
        //                DataTable dt = new DataTable();
        //                if (sdr.HasRows)
        //                {
        //                    dt.Load(sdr);
        //                    DataRow row = dt.Rows[0];
        //                    product.Name = row["Name"].ToString();
        //                    product.Id = Convert.ToInt32(row["Id"]);
        //                    product.Price = Convert.ToDouble(row["Price"]);
        //                    product.Supplier = row["Supplier"].ToString();
        //                    return View("Create", product);

        //                }
        //                else
        //                {
        //                    return HttpNotFound();
        //                }

        //            }
        //        }
        //    }
        //} 
    }

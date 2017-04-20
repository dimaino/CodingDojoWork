using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class StoreController : Controller
    {
        MasterContext _context;

        public StoreController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Order> SomeOrders = _context.Order.Include(o => o.Product).Include(o => o.Customer).Take(3).ToList();
            ViewBag.someOrders = SomeOrders;
            List<Customer> SomeCustomer = _context.Customer.Take(3).ToList();
            ViewBag.someCustomer = SomeCustomer;
            List<Product> SomeProducts = _context.Product.Take(5).ToList();
            ViewBag.someProducts = SomeProducts;
            return View("Index");
        }

        [HttpGet]
        [Route("orders")]
        public IActionResult Orders()
        {
            List<Customer> AllCustomers = _context.Customer.ToList();
            ViewBag.allCustomers = AllCustomers;
            List<Product> AllProducts = _context.Product.ToList();
            ViewBag.allProducts = AllProducts;
            List<Order> AllOrders = _context.Order.Include(o => o.Product).Include(o => o.Customer).ToList();
            ViewBag.allOrders = AllOrders;
            return View("Orders");
        }

        [HttpGet]
        [Route("customers")]
        public IActionResult Customers()
        {
            List<Customer> AllCustomers = _context.Customer.ToList();
            ViewBag.allCustomers = AllCustomers;
            ViewBag.errors_list = TempData["Errors"];
            return View("Customers");
        }

        [HttpGet]
        [Route("products")]
        public IActionResult Products()
        {
            List<Product> AllProducts = _context.Product.ToList();
            ViewBag.allProducts = AllProducts;
            return View("Products");
        }

        [HttpGet]
        [Route("settings")]
        public IActionResult Settings()
        {
            return View("Settings");
        }

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("addCustomer")]
        public IActionResult AddCustomer(string Customer_Name)
        {
            List<string> errors = new List<string>();
            if(Customer_Name != null)
            {
                Customer checkForCustomer = _context.Customer.SingleOrDefault(customer => customer.Customer_Name == Customer_Name);
                if(checkForCustomer == null)
                {
                    Customer newCutomer = new Customer
                    {
                        Customer_Name = Customer_Name,
                    };
                    _context.Add(newCutomer);
                    _context.SaveChanges();
                    return RedirectToAction("Customers");
                }
                errors.Add("Customer already exists.");
            }
            else
            {
                errors.Add("You need to enter a customers name.");
            }
            TempData["Errors"] = errors;
            return RedirectToAction("Customers");
        }

        [HttpPost]
        [Route("deleteCustomer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            Customer currentCustomer = _context.Customer.SingleOrDefault(customer => customer.id == id);
            _context.Remove(currentCustomer);
           _context.SaveChanges();
            return RedirectToAction("Customers");
        }

        [HttpPost]
        [Route("addProduct")]
        public IActionResult AddProduct(string Product_Name, string Image_Url, string Description, int Quantity)
        {
            Product newProduct = new Product
            {
                Product_Name = Product_Name,
                Image_Url = Image_Url,
                Description = Description,
                Quantity = Quantity,
            };
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Products");
        }

        [HttpPost]
        [Route("addOrder")]
        public IActionResult AddOrder(int customer_id, int Quantity, int product_id)
        {
            Product currentProduct = _context.Product.SingleOrDefault(p => p.id == product_id);
            Order newOrder = new Order
            {
                customer_id = customer_id,
                Quantity = Quantity,
                product_id = product_id,
            }; 
            currentProduct.Quantity -= newOrder.Quantity;
            _context.Add(newOrder);
            _context.SaveChanges();
            return RedirectToAction("Orders");
        }
    }
}

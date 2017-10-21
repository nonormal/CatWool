using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatWool.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace CatWool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var product = _dbContext.Products
                .Include(c => c.Size)
                .Include(c => c.Status)
                .Include(c => c.User)
                .Where(w => w.StatusId == true);
            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Get: details
        public ActionResult DetailsUser(int id)
        {
            var product = _dbContext.Products
                .Include(c => c.Size)
                .Include(c => c.User)
                .Include(c => c.Status)
                .Single(c => c.Id == id && c.StatusId == true);
            return View(product);
        }


        //POST: AddToCart - Thêm sản phẩm vào giỏ hàng
        [HttpPost]
        public JsonResult AddToCart(int id)
        {
            List<CartItem> listCartItem;

            //xử lý thêm sản phẩm vào giỏ hàng
            if (Session["ShoppingCart"] == null)
            {
                //Tạo mới biến Session Shopping Cart
                listCartItem = new List<CartItem>();
                listCartItem.Add(new CartItem {Amount = 1, Product = _dbContext.Products.Find(id)});

                Session["ShoppingCart"] = listCartItem;
            }
            else
            {
                bool flag = false;
                listCartItem = (List<CartItem>) Session["ShoppingCart"];
                foreach (CartItem item in listCartItem)
                {
                    if (item.Product.Id == id)
                    {
                        item.Amount++;
                        flag = true;
                        break;

                    }
                }
                if (!flag)
                {
                    listCartItem.Add(new CartItem {Amount = 1, Product = _dbContext.Products.Find(id)});
                }
                Session["ShoppingCart"] = listCartItem;
            }

            //đếm số lượng sản phẩm trong shopping cart
            int cartcount = 0;
            List<CartItem> ls = (List<CartItem>) Session["ShoppingCart"];
            foreach (CartItem item in ls)
            {
                cartcount += item.Amount;
            }

            return Json(new {ItemAmount = cartcount});
        }

        //Lấy sô lượng sản phẩm trong shopping cart

        public ActionResult GetShoppingCart()
        {
            int cartcount = 0;
            if (Session["ShoppingCart"] != null)
            {
                //Đếm số sản phẩm trong shopping cart
                List<CartItem> ls = (List<CartItem>) Session["ShoppingCart"];
                foreach (CartItem item in ls)
                {
                    cartcount += item.Amount;
                }
            }
            return PartialView("ShoppingCartPartial", cartcount);
        }

        //Hiển thị sản phẩm trong giỏ hàng
        public ActionResult ListCartItem()
        {
            return View();
        }

        public List<CartItem> GetCart()
        {
            List<CartItem> sp = Session["ShoppingCart"] as List<CartItem>;
            if (sp == null)
            {
                sp = new List<CartItem>();
                Session["ShoppingCart"] = sp;
            }

            return sp;
        }


        //Get
        [Authorize]
        public ActionResult CheckOut()
        {
            return View();
        }

        //Post
        [HttpPost]
        [Authorize]
        public ActionResult CheckOut(Customer model)
        {
            //Nhập thông tin khách hàng
            var customer = new Customer
            {
                UserId = User.Identity.GetUserId(),
                NameCustomer = model.NameCustomer,
                Address = model.Address,
                City = model.City,
                Phone = model.Phone
            };

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return RedirectToAction("SaveOrder", "Home");

        }


        //Post
        [Authorize]
        public ActionResult SaveOrder(Customer model)
        {

            List<CartItem> sp = GetCart();

            int id = model.Id;
            
            //Tạo đơn hàng
            Order order = new Order();

            order.CustomerId = id;
            order.DateTime = DateTime.Now;
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            //Chi tiết đơn hàng
            foreach (var item in sp)
            {
                DetailOrder detailOrder = new DetailOrder();

                detailOrder.OrderId = order.Id;
                detailOrder.ProductId = item.Product.Id;
                detailOrder.Amount = item.Amount;

                _dbContext.DetailOrders.Add(detailOrder);
            }
            _dbContext.SaveChanges();
            Session["ShoppingCart"] = null;

            //return Content("<script>alert('Đơn hàng đặt thành công, chúng tôi sẽ liên hệ lại sau')</script>");

            return RedirectToAction("Index", "Home", Content("<script>alert('Đơn hàng đặt thành công, chúng tôi sẽ liên hệ lại sau')</script>"));
        }
    }
}
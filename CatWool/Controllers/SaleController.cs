using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatWool.Models;
using CatWool.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace CatWool.Controllers
{
    public class SaleController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public SaleController()
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


        //GET : BanHang
        [Authorize]
        public ActionResult AddProduct()
        {
            var viewModel = new ProductViewModel
            {
                Sizes = _dbContext.Sizes.ToList(),
                Statuses = _dbContext.Statuses.ToList()
            };

            return View(viewModel);
        }


        // POST: BanHang
        [Authorize]
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Sizes = _dbContext.Sizes.ToList();
                viewModel.Statuses = _dbContext.Statuses.ToList();
                return View("AddProduct", viewModel);
            }
            var product = new Product
            {
                UserId = User.Identity.GetUserId(),
                NameProduct = viewModel.NameProduct,
                SizeId = viewModel.Size,
                Describe = viewModel.Describe,
                Price = viewModel.Price,
                PricePromotion = viewModel.PricePromotion,
                Image = viewModel.Image,
                StatusId = viewModel.Status
            };

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return RedirectToAction("AddProduct", "Sale");
        }
    }
}
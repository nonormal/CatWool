using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatWool.Models;
using CatWool.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Security.Cryptography;

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
                Statuses = _dbContext.Statuses.ToList(),
                Heading="Add Product"
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

        //Get: Delete
        [Authorize]
        public ActionResult Delete(int id)
        {
            var product = _dbContext.Products
                .Include(c => c.Size)
                .Include(c => c.User)
                .Include(c => c.Status)
                .Single(c => c.Id == id && c.StatusId == true);
            return View(product);
        }

        //Post: Delete
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id,Product product)
        {
            product = _dbContext.Products
                .Include(c => c.Size)
                .Include(c => c.User)
                .Include(c => c.Status)
                .Single(c => c.Id == id);
            product.StatusId = false;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Sale");
        }

        //Index-Delete
        public ActionResult IndexDelete()
        {
            var product = _dbContext.Products
                .Include(c => c.Size)
                .Include(c => c.Status)
                .Include(c => c.User)
                .Where(w => w.StatusId == false);
            return View(product);
        }

        //Get: Redelete
        [Authorize]
        public ActionResult ReDelete(int id)
        {
            var product = _dbContext.Products
                .Include(c => c.Size)
                .Include(c => c.User)
                .Include(c => c.Status)
                .Single(c => c.Id == id);
            return View(product);
        }

        //Post: Redeltte
        [Authorize]
        [HttpPost]
        public ActionResult ReDelete(int id, Product product)
        {
            product = _dbContext.Products
                .Include(c => c.Size)
                .Include(c => c.User)
                .Include(c => c.Status)
                .Single(c => c.Id == id);
            product.StatusId = true;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Sale");
        }

        //Get: edit
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var product = _dbContext.Products.Single(c => c.Id == id && c.UserId == userId);

            var viewModel = new ProductViewModel
            {
                Sizes = _dbContext.Sizes.ToList(),
                Statuses = _dbContext.Statuses.ToList(),
                NameProduct = product.NameProduct,
                Price = product.Price,
                PricePromotion = product.PricePromotion,
                Size = product.SizeId,
                Status = product.StatusId,
                Describe = product.Describe,
                Image = product.Image,
                Heading="Edit Product",
                Id=product.Id
            };
            return View("AddProduct", viewModel);
        }


        //Post: edit
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductViewModel viewoModel)
        {
            if (!ModelState.IsValid)
            {
                viewoModel.Statuses = _dbContext.Statuses.ToList();
                viewoModel.Sizes = _dbContext.Sizes.ToList();
                return View("AddProduct", viewoModel);
            }
            var userId = User.Identity.GetUserId();
            var product = _dbContext.Products.Single(c => c.Id == viewoModel.Id && c.UserId == userId);

            product.NameProduct = viewoModel.NameProduct;
            product.Price = viewoModel.Price;
            product.PricePromotion = viewoModel.PricePromotion;
            product.Describe = viewoModel.Describe;
            product.Image = viewoModel.Image;
            product.StatusId = viewoModel.Status;
            product.SizeId = viewoModel.Size;
            
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Sale");
        }


        //Get: details
        public ActionResult Details()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CatWool.Models
{
    public class CartItem
    {
        //Tạo dữ liệu data chứa dữ liệu từ model db bán sách đã tạo
        /*private readonly ApplicationDbContext _dbContext;

        public CartItem()
        {
            _dbContext = new ApplicationDbContext();
        }

        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public string NameProduct { get; set; }

        public Size Size { get; set; }
     
        public byte SizeId { get; set; }

        public string Describe { get; set; }
        public float Price { get; set; }
        public float PricePromotion { get; set; }
        public string Image { get; set; }

        public int Amount { get; set; }

        //Thành tiền
        public float PaidMoney
        {
            get { return Amount * Price; }
        }

        public CartItem(int id)
        {
            Id = id;
            Product product = _dbContext.Products.Single(n => n.Id == Id);
            NameProduct = product.NameProduct;
            SizeId = product.SizeId;
            Describe = product.Describe;
            Price = float.Parse(product.Price.ToString());
            PricePromotion = float.Parse(product.PricePromotion.ToString());
            Image = product.Image;

            Amount = 1;

        }*/

        public Product Product { get; set; }

        public int Amount { get; set; }


    }
}
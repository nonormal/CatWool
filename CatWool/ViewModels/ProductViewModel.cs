using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CatWool.Models;

namespace CatWool.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tên Sản Phẩm")]
        [Required(ErrorMessage ="Tên sản phẩm không được trống")]
        [StringLength(255)]
        public string NameProduct { get; set; }

        [Required(ErrorMessage ="Kích thước không được trống")]
        public byte Size { get; set; }

        public string Describe { get; set; }

        [Required(ErrorMessage ="Đơn giá không được trống")]
        public float Price { get; set; }

        [Required(ErrorMessage ="Đơn giá khuyến mãi không được trống")]
        public float PricePromotion { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage ="Trạng thái không được trống")]
        public bool Status { get; set; }

        public IEnumerable<Size> Sizes { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
        public string Heading { get; set; }

        public string Action
        {
            get
            {
                return (Id != 0) ? "Update" : "AddProduct";
            }
        }

    }
}
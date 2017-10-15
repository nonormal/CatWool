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
        [Display(Name = "Tên Sản Phẩm")]

        [Required]
        [StringLength(255)]
        public string NameProduct { get; set; }
        [Required]
        public byte Size { get; set; }
        public string Describe { get; set; }

        [Required]
        public float Price { get; set; }
        [Required]
        public float PricePromotion { get; set; }
        public string Image { get; set; }
        [Required]

        public bool Status { get; set; }

        public IEnumerable<Size> Sizes { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
    }
}
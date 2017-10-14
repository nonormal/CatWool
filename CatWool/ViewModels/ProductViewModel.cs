using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CatWool.Models;

namespace CatWool.ViewModels
{
    public class ProductViewModel
    {
        public string NameProduct { get; set; }
        public byte Size { get; set; }
        public string Describe { get; set; }
        public float Price { get; set; }
        public float PricePromotion { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }

        public IEnumerable<Size> Sizes { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
    }
}
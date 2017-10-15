using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CatWool.Models
{
    public class Product
    {
        public byte Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }


        [Required]
        [StringLength(255)]
        public string NameProduct { get; set; }

        public Size Size { get; set; }
        [Required]
        public byte SizeId { get; set; }

        public string Describe { get; set; }
        public float Price { get; set; }
        public float PricePromotion { get; set; }
        public string Image { get; set; }

        public Status Status { get; set; }
        [Required]
        public bool StatusId { get; set; }
    }
}
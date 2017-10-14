using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CatWool.Models
{
    public class Customer
    {
        public byte Id { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }
       
        [Required]
        [StringLength(255)]
        public string NameCustomer { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public byte City { get; set; }
        
    }
}
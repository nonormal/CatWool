using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatWool.Models
{
    public class DetailOrder
    {
        [Key]
        [Column(Order = 1)]
        public byte OrderId { get; set; }
        [Key]
        [Column(Order = 2)]
        public byte ProductId { get; set; }
        public int Amount { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace CatWool.Models
{
    public class Size
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace CatWool.Models
{
    public class Status
    {
        public bool Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
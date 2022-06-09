using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_seminar.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 2)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string? ImageName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CMS_seminar.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250, MinimumLength =2)]
        public string Title { get; set; }
    }
}

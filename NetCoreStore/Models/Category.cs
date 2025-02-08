using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NetCoreStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,50,ErrorMessage = "Display order must be between 1-50")]
        public int DisplayOrder { get; set; }
    }
}

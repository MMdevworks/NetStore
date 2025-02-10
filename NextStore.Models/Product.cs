using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Brand { get; set; }

        [Required]
        [DisplayName("List Price")]
        [Range(0.1, 10000)]
        public double ListPrice { get; set; }

        [Required]
        [DisplayName("Price for 1")]
        [Range(0.1, 10000)]
        public double Price { get; set; }

        [Required]
        [DisplayName("Price for 2")]
        [Range(0.1, 10000)]
        public double Price2 { get; set; }

        [Required]
        [DisplayName("Price for 3+")]
        [Range(0.1, 10000)]
        public double Price3 { get; set; }
        //public int Stock { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}

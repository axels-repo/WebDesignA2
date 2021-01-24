using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _12246765_OnlineStore.Models
{
    public partial class Product
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "The Product name cannot be blank")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter a product name between 3 and 50 characters in length")]
        [RegularExpression(@"^[a-zA-z0-9'-'\s]*$", ErrorMessage = "Please enter a product name made up of only letters and spaces")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The product description cannot be blank")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Please enter a product description between 10 and 300 characters in length")]
        [RegularExpression(@"^[a-zA-Z0-9'-'\s]*$", ErrorMessage = "Please enter a product description made up of only letters and spaces")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The Product price cannot be blank")]
        [Range(0.01, 100000, ErrorMessage = "Please enter a product price between 0.01 and 100000")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [RegularExpression("[0-9]+(\\.[0-9)][0-9]?)?", ErrorMessage = "The Price must be a number upto two decimal places")]
        public decimal Price { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductImageMapping> ProductImageMappings { get; set; }
    }
}
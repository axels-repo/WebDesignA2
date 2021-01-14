using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _12246765_OnlineStore.Models
{
    public partial class Category
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Category")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
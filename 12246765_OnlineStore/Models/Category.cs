﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _12246765_OnlineStore.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
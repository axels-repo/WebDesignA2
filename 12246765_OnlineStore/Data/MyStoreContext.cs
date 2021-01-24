using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _12246765_OnlineStore.Data
{
    public class MyStoreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MyStoreContext() : base("name=MyStoreContext")
        {
            
        }

        public System.Data.Entity.DbSet<_12246765_OnlineStore.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<_12246765_OnlineStore.Models.Product> Products { get; set; }
        public System.Data.Entity.DbSet<_12246765_OnlineStore.Models.ProductImage> ProductImages { get; set; }

        public System.Data.Entity.DbSet<_12246765_OnlineStore.Models.ProductImageMapping> ProductImageMappings { get; set; }
    }
}

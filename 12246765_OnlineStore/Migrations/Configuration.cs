namespace _12246765_OnlineStore.Migrations
{
    using _12246765_OnlineStore.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_12246765_OnlineStore.Data.MyStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_12246765_OnlineStore.Data.MyStoreContext context)
        {
            var categories = new List<Category>
            {
                new Category {Name = "Tents" },
                new Category {Name = "Sleeping Bags" },
                new Category {Name = "Hiking Packs" },
 };
            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
            var products = new List<Product>
 {
                new Product {Name = "Three Season Down Sleeping Bag", Description = "Down Sleeping Bag Good for three season camping", Price = 300, CategoryID= categories.Single(c=>c.Name == "Sleeping Bags").ID},
                new Product {Name = "Three Season Synthetic Sleeping Bag", Description = "Synthetic Sleeping Bag Good for three season camping", Price = 150, CategoryID= categories.Single(c=>c.Name == "Sleeping Bags").ID},
                new Product {Name = "Harsh Condition Down Sleeping Bag", Description = "Down Sleeping Bag Good for cold hard conditions camping", Price = 500, CategoryID= categories.Single(c=>c.Name == "Sleeping Bags").ID},
                new Product {Name = "Day Hiking Pack", Description = "Pack suitable for daytrips", Price = 100, CategoryID= categories.Single(c=>c.Name == "Hiking Packs").ID},
                new Product {Name = "Medium Hiking Pack", Description = "Pack suitable for one to two nights camping", Price = 300, CategoryID= categories.Single(c=>c.Name == "Hiking Packs").ID},
                new Product {Name = "Large Hiking Pack", Description = "Pack suitable for long hiking trips", Price = 450, CategoryID= categories.Single(c=>c.Name == "Hiking Packs").ID},
                new Product {Name = "Ultralight Tent one person", Description = "Ultralight Tent for one person thru hikes", Price = 300, CategoryID= categories.Single(c=>c.Name == "Tents").ID},
                new Product {Name = "Ultralight Tent two person", Description = "Ultralight Tent for two person thru hikes", Price = 400, CategoryID= categories.Single(c=>c.Name == "Tents").ID},
                new Product {Name = "Car Camping Tent four person", Description = "Heavier tent for car camping", Price = 450, CategoryID= categories.Single(c=>c.Name == "Tents").ID},
            };
            products.ForEach(c => context.Products.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
        }
    }
}

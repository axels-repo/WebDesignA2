namespace _12246765_OnlineStore.Migrations.StoreConfiguration
{
    using _12246765_OnlineStore.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class StoreConfiguration : DbMigrationsConfiguration<_12246765_OnlineStore.Data.MyStoreContext>
    {
        public StoreConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_12246765_OnlineStore.Data.MyStoreContext context)
        {

            var categories = new List<Category>
 {
                new Category {Name = "Hiking Gear" },
                new Category {Name = "Sleeping Bags" },
                new Category {Name = "Tents" },
                new Category {Name = "Backpacks" },
            };
            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product {Name = "Three Season Sleeping Bag", Description = "Good for three seasons camping", Price = 149, CategoryID= categories.Single(c=>c.Name == "Sleeping Bags").ID},
                new Product {Name = "Winter Season Sleeping Bag", Description = "Good for cold season camping", Price = 199, CategoryID= categories.Single(c=>c.Name == "Sleeping Bags").ID},
                new Product {Name = "Summer Sleeping Bag", Description = "Good for hot weather camping", Price = 99, CategoryID= categories.Single(c=>c.Name == "Sleeping Bags").ID},
                new Product {Name = "Solo Hiking Tent", Description = "Ultralight tent for one person", Price = 149, CategoryID= categories.Single(c=>c.Name == "Tents").ID},
                new Product {Name = "Duo Hiking Tent", Description = "Ultralight tent for two persons", Price = 199, CategoryID= categories.Single(c=>c.Name == "Tents").ID},
                new Product {Name = "Trio Hiking Tent", Description = "Ultralight tent for three persons", Price = 249, CategoryID= categories.Single(c=>c.Name == "Tents").ID},
                new Product {Name = "Small Hiking Bag", Description = "Good for daytrips", Price = 149, CategoryID= categories.Single(c=>c.Name == "Backpacks").ID},
                new Product {Name = "Medium Hiking Bag", Description = "Good for a few nights camping", Price = 349, CategoryID= categories.Single(c=>c.Name == "Backpacks").ID},
                new Product {Name = "Jumbo Hiking Bag", Description = "Good for weekling adventures", Price = 499, CategoryID= categories.Single(c=>c.Name == "Backpacks").ID},
                new Product {Name = "Gas Bottle", Description = "Gas bottle to use with camping stove", Price = 10, CategoryID= categories.Single(c=>c.Name == "Hiking Gear").ID},
                new Product {Name = "Camping Stove", Description = "Camping stove used for hiking to be used with gas bottles", Price = 49, CategoryID= categories.Single(c=>c.Name == "Hiking Gear").ID},
            };
            products.ForEach(c => context.Products.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var orders = new List<Order>
 {
 new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street",
Town="Town1",
 Country="Country", PostCode="PostCode" }, TotalPrice=149,
 UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 1) ,
 DeliveryName="Admin" },
 new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street",
Town="Town1",
 Country="Country", PostCode="PostCode" }, TotalPrice=149,
 UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 2) ,
 DeliveryName="Admin" },
 new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street",
Town="Town1",
 Country="Country", PostCode="PostCode" }, TotalPrice=449,
 UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 3) ,
 DeliveryName="Admin" },
 new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street",
Town="Town1",
 Country="County", PostCode="PostCode" }, TotalPrice=49,
 UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 4) ,
 DeliveryName="Admin" },
 new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street",
Town="Town1",
 Country="Country", PostCode="PostCode" }, TotalPrice=249,
 UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 5) ,
 DeliveryName="Admin" },
 new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street",
Town="Town1",
 Country="Country", PostCode="PostCode" }, TotalPrice=99,
 UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 7) ,
 DeliveryName="Admin" }
 };
            orders.ForEach(c => context.Orders.AddOrUpdate(o => o.DateCreated, c));
            context.SaveChanges();



            var orderLines = new List<OrderLine> 
            {
                new OrderLine { OrderID = 1, ProductID = products.Single( c=> c.Name ==
                "Three Season Sleeping Bag").ID,
                    ProductName ="Three Season Sleeping Bag", Quantity =1, UnitPrice=products.Single( c=>
                    c.Name == "Three Season Sleeping Bag").Price },
                new OrderLine { OrderID = 2, ProductID = products.Single( c=> c.Name ==
                "Small Hiking Bag").ID,
                    ProductName ="Small Hiking Bag", Quantity =1, UnitPrice=products.Single( c=>
                    c.Name == "Small Hiking Bag").Price },
                new OrderLine { OrderID = 3, ProductID = products.Single( c=> c.Name ==
                "Jumbo Hiking Bag").ID,
                    ProductName ="Jumbo Hiking Bag", Quantity =1, UnitPrice=products.Single( c=>
                    c.Name == "Jumbo Hiking Bag").Price },
                new OrderLine { OrderID = 4, ProductID = products.Single( c=> c.Name ==
                "Camping Stove").ID,
                    ProductName ="Camping Stove", Quantity =1, UnitPrice=products.Single( c=>
                    c.Name == "Camping Stove").Price },
                new OrderLine { OrderID = 5, ProductID = products.Single( c=> c.Name ==
                "Trio Hiking Tent").ID,
                    ProductName ="Trio Hiking Tent", Quantity =1, UnitPrice=products.Single( c=>
                    c.Name == "Trio Hiking Tent").Price },
                new OrderLine { OrderID = 6, ProductID = products.Single( c=> c.Name ==
                "Summer Sleeping Bag").ID,
                    ProductName ="Summer Sleeping Bag", Quantity =1, UnitPrice=products.Single( c=>
                    c.Name == "Summer Sleeping Bag").Price },
            };
            orderLines.ForEach(c => context.OrderLines.AddOrUpdate(ol => ol.OrderID, c));
            context.SaveChanges();


        }
    }

    }


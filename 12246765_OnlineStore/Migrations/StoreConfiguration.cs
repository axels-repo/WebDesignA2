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
        }
    }
}

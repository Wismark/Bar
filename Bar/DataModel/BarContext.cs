namespace Bar.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BarContext : DbContext
    {
        
        public BarContext()
            : base("name=BarContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tara> Tars { get; set; }
    }

}
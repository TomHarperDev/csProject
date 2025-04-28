using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ThomasHarper_Cs_Project.Data
{
    public class MyLocalDbContext : DbContext
    {
        public MyLocalDbContext() : base("name=MyDatabaseConnection") // Name of the connection string in the config file
        {
            // Optional: Configure database initialization strategy
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyLocalDbContext>());
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyLocalDbContext>());
            // Database.SetInitializer(null); // No initialization
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Optional: Configure relationships, constraints, etc.
            // For example, configuring the foreign key relationship between Order and Customer:
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            // If using SQLite, ensure the provider factory is registered
            var connection = Database.Connection as SQLiteConnection;
            if (connection != null)
            {
                modelBuilder.Entity<Customer>().Property(c => c.CustomerId).HasColumnName("CustomerId"); // Example of explicit column mapping
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}

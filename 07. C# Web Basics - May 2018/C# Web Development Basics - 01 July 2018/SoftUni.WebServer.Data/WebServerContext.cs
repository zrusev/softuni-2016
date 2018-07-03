namespace SoftUni.WebServer.Data
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.WebServer.Models;

    public class WebServerContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductOrder> ProductOrder { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string connectionString = "Data Source=(LocalDB)\\LocalDB;Database=Chushka_zlatko.rusev;Integrated Security=True";
                builder.UseSqlServer(connectionString);
            }

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductOrder>(entity =>
            {
                entity.HasKey(k => new { k.IdProduct, k.IdOrder });

                entity.HasOne(o => o.Product)
                    .WithMany(p => p.OrderNavigation)
                    .HasForeignKey(k => k.IdProduct);

                entity.HasOne(p => p.Order)
                    .WithMany(o => o.ProductNavigation)
                    .HasForeignKey(k => k.IdOrder);
            });

            base.OnModelCreating(builder);
        }
    }
}

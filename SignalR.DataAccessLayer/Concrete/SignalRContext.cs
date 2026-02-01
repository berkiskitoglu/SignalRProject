using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Concrete
{
    public class SignalRContext : DbContext
    {
        public SignalRContext(DbContextOptions<SignalRContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ============================================
            // BASKET PRODUCTS - Composite PK
            // ============================================
            modelBuilder.Entity<BasketProduct>()
                .HasKey(bp => new { bp.BasketID, bp.ProductID });

            modelBuilder.Entity<BasketProduct>()
                .HasOne(bp => bp.Basket)
                .WithMany(b => b.BasketProducts)
                .HasForeignKey(bp => bp.BasketID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BasketProduct>()
                .HasOne(bp => bp.Product)
                .WithMany(p => p.BasketProducts)
                .HasForeignKey(bp => bp.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================================
            // BASKET - ORDER (1:1 optional)
            // ============================================
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Basket)
                .WithOne()
                .HasForeignKey<Order>(o => o.BasketID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================================
            // INDEXES
            // ============================================
            modelBuilder.Entity<Basket>()
                .HasIndex(b => b.MenuTableID);

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.Date);

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.MenuTableID);

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.CategoryID);
        }

        // DbSets
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocailMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<MoneyCase> MoneyCases { get; set; }
        public DbSet<MenuTable> MenuTables { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
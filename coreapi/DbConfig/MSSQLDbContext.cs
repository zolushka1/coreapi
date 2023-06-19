using coreapi.BusinessObjects.Count;
using coreapi.BusinessObjects.Invoice;
using coreapi.BusinessObjects.NonDC;
using Microsoft.EntityFrameworkCore;

namespace coreapi.DbConfig
{
    public class MSSQLDbContext : DbContext
    {
        public MSSQLDbContext(DbContextOptions<MSSQLDbContext> options) : base(options) { }

        // Table register
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<ItemLoss> ItemLosses { get; set; }
        public DbSet<ItemLossItem> ItemLossItems { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<PhoneUser> PhoneUsers { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory"); // Set the table name (optional)
                entity.HasKey(e => e.Id); // Set the primary key
                entity.Property(e => e.Id).HasMaxLength(50).IsRequired(); // Configure the Id property
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired(); // Configure the Name property
                entity.Property(e => e.Description).HasMaxLength(255); // Configure the Description property (optional)

                // Configure the one-to-many relationship with PhoneUser
                entity.HasMany(e => e.PhoneUsers)
                    .WithOne(e => e.Inventory)
                    .HasForeignKey(e => e.InventoryId)
                    .IsRequired();

                // Configure the one-to-many relationship with InventoryItem
                entity.HasMany(e => e.InventoryItems)
                    .WithOne(e => e.Inventory)
                    .HasForeignKey(e => e.InventoryId)
                    .IsRequired();
            });

            modelBuilder.Entity<InventoryItem>(entity =>
            {

            });

            modelBuilder.Entity<Invoice>(entity =>
            {

            });

            modelBuilder.Entity<InvoiceItem>(entity =>
            {

            });

            modelBuilder.Entity<ItemLoss>(entity =>
            {

            });

            modelBuilder.Entity<ItemLossItem>(entity =>
            {

            });

            modelBuilder.Entity<Item>(entity =>
            {

            });

            modelBuilder.Entity<PhoneUser>(entity =>
            {

            });

            modelBuilder.Entity<User>(entity =>
            {

            });
        }

        private void MigrateDatabase()
        {
            // Бааз болон table - үүсгэж байгаа үйлдэл
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Баазтай холбогдох тохиргоо

            // 1. SqlServerAuthentication - тай холбогдох үед
            string connectionString = "Server=192.82.95.103,1456;Database=WebPos;User Id=sa;Password=0nTime@123;TrustServerCertificate=true";

            // 2. Windows Authentication - тай холбогдох үед
            //string connectionString = "Data Source=DESKTOP-79FDGV8;Initial Catalog=WebPos;Integrated Security=True;";
            //string connectionString = "Data Source=./MSSQLSERVER;Initial Catalog=WebPos;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

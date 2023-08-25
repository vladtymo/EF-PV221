using data_access.Data;
using data_access.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace data_access
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext() : base()
        {
            //this.Database.EnsureDeleted();
            // create database if does not exists
            //this.Database.EnsureCreated();

            // Use Migrations instead: (install NuGet: EFCore.Tools)
            // - add-migration <MigrationName> - add new migration with available changes
            // - update-migration              - update the database by the newest migration
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseLazyLoadingProxies();

            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NullCafeDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ---------------- FluentAPI Configurations
            modelBuilder.ApplyConfiguration(new EmployeeConfigs());

            modelBuilder.Entity<Order>().HasKey(x => x.Number);
            modelBuilder.Entity<Order>().HasMany(x => x.Dishes).WithMany(x => x.Orders);

            // data initialization
            //DbExtensions.SeedData(modelBuilder);
            modelBuilder.SeedData();
        }

        // Object Collections (Tables in SQL)
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Resume> Resumes { get; set; }
    }
}
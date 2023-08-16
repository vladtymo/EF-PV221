using Microsoft.EntityFrameworkCore;

namespace _01_intro_to_ef
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext() : base()
        {
            //this.Database.EnsureDeleted();
            // create database if does not exists
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NullCafeDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // data initialization
            modelBuilder.Entity<Position>().HasData(new[]
            {
                new Position() { Id = 1, Name = "Waiter" },
                new Position() { Id = 2, Name = "Chef" },
                new Position() { Id = 3, Name = "Administrator" },
                new Position() { Id = 4, Name = "Barman" }
            });
        }

        // Object Collections (Tables in SQL)
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
    }
}
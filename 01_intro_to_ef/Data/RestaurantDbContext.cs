using Microsoft.EntityFrameworkCore;

namespace _01_intro_to_ef
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

            modelBuilder.Entity<Employee>().HasData(new Employee[]
            {
                new()
                {
                    Id = 1,
                    Name = "Andrii",
                    PositionId = 2,
                    Surname = "Povar",
                    Birthdate = new DateTime(1988, 4, 10),
                    Salary = 1200
                }
            });

            modelBuilder.Entity<Resume>().HasData(new Resume[]
            {
                new()
                {
                     Id = 1,
                     Certified = true,
                     EmployeeId = 1,
                     Summary = "I am a great cook!",
                     Experience = 2
                }
            });
        }

        // Object Collections (Tables in SQL)
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Resume> Resumes { get; set; }
    }
}
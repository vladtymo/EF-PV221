using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_intro_to_ef.Data
{
    public static class DbExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
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
                    PositionNumber = 2,
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
    }
}

using Microsoft.EntityFrameworkCore;

namespace _01_intro_to_ef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestaurantDbContext db = new();

            // --------------------- add 
            //db.Dishes.Add(new Dish()
            //{
            //    Price = 145,
            //    Title = "Lobsters",
            //    Weight = 220,
            //    Description = "I like it!"
            //});

            //db.SaveChanges(); // submit changes

            // --------------------- read data
            //var data = db.Dishes.Where(x => x.Price < 1000).OrderBy(x => x.Weight);

            //foreach (var i in data)
            //{
            //    Console.WriteLine($"Dish {i.Title} - {i.Price}$ {i.Weight}g {i.Rating}");
            //}
            
            LoadingTypes(db);
        }

        static void LoadingTypes(RestaurantDbContext db)
        {
            // ----------------- Loading Types
            // 1 - eager loading
            var emps = db.Employees.Include(x => x.Position)
                                   .Include(x => x.Orders).ThenInclude(x => x.Dishes);

            // Employees LEFT JOIN Positions

            Console.WriteLine("Employees:");
            foreach (var i in emps)
            {
                Console.WriteLine($"[{i.Id}] {i.Name} {i.Salary}$ {i.Position.Name}");
            }

            var emp = emps.FirstOrDefault();
            Console.WriteLine($"{emp.Name} {emp.Surname}, orders: {emp.Orders.Count}");

            foreach (var i in emp.Orders)
            {
                Console.WriteLine("Order: " + i.Number + " " + i.Date);
                foreach (var d in i.Dishes)
                {
                    Console.WriteLine("\t" + d.Title);
                }
            }

            // 2 - lazy loading

            var emps2 = db.Employees;

            Console.WriteLine("Employees:");
            foreach (var i in emps2)
            {
                Console.WriteLine($"[{i.Id}] {i.Name} {i.Salary}$ {i.Position.Name}, {i.Orders.Count}");
            }

            // 3 - explicit loading 
            var emp2 = db.Employees.Find(1);

            // .Reference().Load() - loading single object
            // .Collection().Load() - loading collection object

            Console.WriteLine($"Employee: {emp2.Name} {emp2.Surname}");

            db.Entry(emp2).Reference(x => x.Resume).Load();
            db.Entry(emp2).Collection(x => x.Orders).Load();

            Console.WriteLine(emp2.Resume.Summary);
            Console.WriteLine(emp2.Orders.Count);
        }
    }
}
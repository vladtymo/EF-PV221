namespace _01_intro_to_ef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestaurantDbContext db = new();

            // --------------------- add data
            db.Employees.Add(new()
            {
                Name = "Andrii",
                PositionId = 2,
                Surname = "Povar",
                Birthdate = new DateTime(1988, 4, 10)
            });

            db.Dishes.Add(new Dish()
            {
                Price = 145,
                Title = "Lobsters",
                Weight = 220,
                Description = "I like it!"
            });

            db.SaveChanges(); // submit changes

            // --------------------- read data
            var data = db.Dishes.Where(x => x.Price < 1000).OrderBy(x => x.Weight);

            foreach (var i in data)
            {
                Console.WriteLine($"Dish {i.Title} - {i.Price}$ {i.Weight}g");
            }
        }
    }
}
namespace _01_intro_to_ef
{
    public class Dish
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public int? Rating { get; set; }

        // Relation Type: Many to Many (*...*)
        public ICollection<Order> Orders { get; set; }
    }
}
namespace _01_intro_to_ef
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? WaiterId { get; set; }

        // ----- Navigation Properties
        public virtual Employee? Waiter { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; } = new HashSet<Dish>();
    }
}
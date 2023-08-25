using data_access.Interfaces;

namespace data_access
{
    public class Dish : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public int? Rating { get; set; }

        // Relation Type: Many to Many (*...*)
        public virtual ICollection<Order> Orders { get; set; }
    }
}
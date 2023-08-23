using System.ComponentModel.DataAnnotations;

namespace _01_intro_to_ef
{
    public class Order
    {
        //[Key] // set primary key
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public int? WaiterId { get; set; }

        // ----- Navigation Properties
        public virtual Employee? Waiter { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; } = new HashSet<Dish>();
    }
}
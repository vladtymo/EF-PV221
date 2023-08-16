namespace _01_intro_to_ef
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // ----- Navigation Properties
        public ICollection<Employee> Customers { get; set; }
    }
}
using data_access.Interfaces;

namespace data_access
{
    public class Position : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // ----- Navigation Properties
        public virtual ICollection<Employee> Customers { get; set; }
    }
}
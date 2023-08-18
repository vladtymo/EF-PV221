namespace _01_intro_to_ef
{
    // Entity Classes (Column Definitions in SQL)
    public class Employee
    {
        // PrimaryKey naming: Id id ID EntityName+Id (CustomerId)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public decimal Salary { get; set; }

        // ForeignKey: RelatedEntityName+Key
        public int PositionId { get; set; } // optional

        // ----- Navigation Properties (references)
        // Relation Type: One to Many (1...*)
        public Position Position { get; set; }

        // Relation Type: One to Many (0/1...*)
        public ICollection<Order> Orders { get; set; }

        // Relation Type: One to One (1...1)
        public Resume? Resume { get; set; }
    }
}
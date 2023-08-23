using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_intro_to_ef
{
    // Entity Classes (Column Definitions in SQL)
    //[Table("Workers")] // set table name in db
    public class Employee
    {
        // PrimaryKey naming: Id id ID EntityName+Id (CustomerId)
        public int Id { get; set; }

        //[MaxLength(200)]// set string max len
        //[Required]      // set not null
        public string Name { get; set; }
        public string Surname { get; set; }

        //[Column("DateOfBirth")] // set column name in db
        public DateTime? Birthdate { get; set; }
        public decimal Salary { get; set; }

        //[NotMapped] // ignore column in db
        public string FullName => Name + " " + Surname;

        // ForeignKey: RelatedEntityName+Key
        //[ForeignKey("Position")]
        public int PositionNumber { get; set; } // optional

        // ----- Navigation Properties (references)
        // Relation Type: One to Many (1...*)
        public virtual Position Position { get; set; }

        // Relation Type: One to Many (0/1...*)
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        // Relation Type: One to One (1...1)
        public virtual Resume? Resume { get; set; }
    }
}
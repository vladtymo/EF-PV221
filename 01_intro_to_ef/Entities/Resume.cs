using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_intro_to_ef
{
    // Dependent Entity
    public class Resume
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public int Experience { get; set; }
        public bool Certified { get; set; }
        public string? Description { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}

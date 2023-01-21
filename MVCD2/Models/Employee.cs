using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MVCD2.Models
{
    public class Employee
    {
        [Key]
        public int SSN { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "money")]
        public int? Salary { get; set; }
        public List<WorksOnProject>? WorksOnProjects { get; set; }

        public List<Dependent>? Dependents { get; set; }

        public Employee? SuperVisor { get; set; }
         
        public List<Employee>? Employees { get; set; }

    }
}

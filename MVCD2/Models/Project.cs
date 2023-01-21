using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCD2.Models
{
    public class Project
    {
        [Key]
        public int Number { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        [ForeignKey("Department")]
        public int DeptNum { get; set; }
        public Department? Department { get; set; }

        public  List<WorksOnProject>? WorksOnProjects { get; set; }

    }
}

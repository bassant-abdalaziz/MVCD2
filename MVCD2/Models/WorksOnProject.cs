using System.ComponentModel.DataAnnotations.Schema;

namespace MVCD2.Models
{
    public class WorksOnProject
    {
        public int Hours { get; set; }

        [ForeignKey("Employee")]
        public int ESSN { get; set; }
        public  Employee? Employees { get; set; }

        [ForeignKey("Project")]
        public int projectNum { get; set; }
        public  Project? Project { get; set; }
    }
}

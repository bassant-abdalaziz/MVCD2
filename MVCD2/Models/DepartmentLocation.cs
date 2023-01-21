using System.ComponentModel.DataAnnotations.Schema;

namespace MVCD2.Models
{
    public class DepartmentLocation
    {
        public string? Location { get; set; }

        [ForeignKey("Department")]
        public int DeptNumber { get; set; }
        public  Department? Department { get; set; }
    }
}

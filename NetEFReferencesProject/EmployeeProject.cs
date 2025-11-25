using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFReferencesProject
{
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public DateOnly StartDate { get; set; }
    }
}

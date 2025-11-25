using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFReferencesProject
{
    public class EmployeeProfile
    {
        public int Id { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public Employee Employee { get; set; } = null!;
        public int EmployeeId { get; set; }
    }
}

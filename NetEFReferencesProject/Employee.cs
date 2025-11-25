using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFReferencesProject
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }

        public Position? Position { get; set; }

        public List<Project> Projects { get; set; } = new();
        public List<EmployeeProject> EmployeeProjects { get; set; } = new();

        public EmployeeProfile? EmployeeProfile { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, {Position} in {Company}";
        }
    }
}

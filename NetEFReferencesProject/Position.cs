using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFReferencesProject
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Employee> Employees { get; set; } = new();

        public override string ToString()
        {
            return $"Position: {Name}";
        }
    }
}

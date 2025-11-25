using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFLazyLoadingProject
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual List<Employee> Employees { get; set; } = new();

        public override string ToString()
        {
            return $"Company: {Name}";
        }
    }
}

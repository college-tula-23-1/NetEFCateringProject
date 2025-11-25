using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFLazyLoadingProject
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }

        public virtual Company? Company { get; set; }
        public int? CompanyId { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, {Company}";
        }
    }
}

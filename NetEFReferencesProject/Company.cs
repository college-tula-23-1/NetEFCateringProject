using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFReferencesProject
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Country? Country { get; set; }
        public int? CountryId { get; set; }

        public List<Employee> Employees { get; set; } = new();

        public override string ToString()
        {
            return $"Company: {Name}, {Country}";
        }
    }
}

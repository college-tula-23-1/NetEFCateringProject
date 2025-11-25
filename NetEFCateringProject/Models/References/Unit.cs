using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.References
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Abbr { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

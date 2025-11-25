using NetEFCateringProject.Models.MiddleEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public ICollection<Supplie> Supplies { get; set; } = new List<Supplie>();

        public ICollection<ProductProvider> ProductProviders { get; set; }
            = new List<ProductProvider>();
    }
}

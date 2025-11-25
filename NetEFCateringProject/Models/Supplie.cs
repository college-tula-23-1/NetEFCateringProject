using NetEFCateringProject.Models.MiddleEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models
{
    public class Supplie
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Provider Provider { get; set; } = null!;
        public int ProviderId { get; set; }

        public ICollection<ProductSupplie> ProductSupplies { get; set; }
            = new List<ProductSupplie>();

    }
}

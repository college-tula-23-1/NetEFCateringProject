using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.MiddleEntities
{
    public class ProductProvider
    {
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }

        public Provider Provider { get; set; } = null!;
        public int ProviderId { get; set; }

        public decimal Price { get; set; }
    }
}

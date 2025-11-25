using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.MiddleEntities
{
    public class ProductSupplie
    {
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }

        public Supplie Supplie { get; set; } = null!;
        public int SupplieId { get; set; }

        public DateTime ProductDate { get; set; }
        public decimal Volume { get; set; }
    }
}

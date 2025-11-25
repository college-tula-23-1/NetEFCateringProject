using NetEFCateringProject.Models.MiddleEntities;
using NetEFCateringProject.Models.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ProductCategory? Category { get; set; }
        public int? CategoryId { get; set; }

        public Unit? Unit { get; set; }
        public int? UnitId { get; set; }

        public int? ShelfLife { get; set; }

        public ICollection<ProductDish> ProductDishes { get; set; } 
            = new List<ProductDish>();

        public ICollection<ProductProvider> ProductProviders { get; set; }
            = new List<ProductProvider>();

        public ICollection<ProductSupplie> ProductSupplies { get; set; }
            = new List<ProductSupplie>();
    }
}

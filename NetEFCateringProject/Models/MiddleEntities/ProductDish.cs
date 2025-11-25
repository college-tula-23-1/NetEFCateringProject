using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.MiddleEntities
{
    public class ProductDish
    {
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }

        public Dish Dish { get; set; } = null!;
        public int DishId { get; set; }

        public int Volume { get; set; }

    }
}

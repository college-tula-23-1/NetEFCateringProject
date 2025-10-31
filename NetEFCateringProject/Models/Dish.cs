using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public CategoryDish? Category { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Price { get; set; }
    }
}

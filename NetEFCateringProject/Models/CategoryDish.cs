using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models
{
    public class CategoryDish
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Dish>? Dishes { get; set; }
    }
}

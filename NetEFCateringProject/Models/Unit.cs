using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models
{
    [Index("Abbr", IsUnique = true)]
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [MaxLength(10)]
        public string? Abbr { get; set; }
    }
}

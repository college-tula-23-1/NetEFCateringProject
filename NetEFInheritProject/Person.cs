using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFInheritProject
{
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }

    
    public class Teacher : Person
    {
        public int Experience { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Teacher Experience: {Experience}";
        }
    }

    
    public class Doctor : Person
    {
        public string Specialty { get; set; } = null!;

        public override string ToString()
        {
            return base.ToString() + $", Doctor Speciality: {Specialty}";
        }
    }
}

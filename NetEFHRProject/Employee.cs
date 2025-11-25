using System;
using System.Collections.Generic;

namespace NetEFHRProject;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int? CompanyId { get; set; }

    public int? PositionId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual EmployeeProfile? EmployeeProfile { get; set; }

    public virtual ICollection<EmployeesProject> EmployeesProjects { get; set; } = new List<EmployeesProject>();

    public virtual Position? Position { get; set; }
}

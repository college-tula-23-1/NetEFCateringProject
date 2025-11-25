using System;
using System.Collections.Generic;

namespace NetEFHRProject;

public partial class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<EmployeesProject> EmployeesProjects { get; set; } = new List<EmployeesProject>();
}

using System;
using System.Collections.Generic;

namespace NetEFHRProject;

public partial class EmployeesProject
{
    public int EmployeeId { get; set; }

    public int ProjectId { get; set; }

    public DateOnly StartDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}

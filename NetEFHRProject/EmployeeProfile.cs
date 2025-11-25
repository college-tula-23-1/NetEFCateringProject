using System;
using System.Collections.Generic;

namespace NetEFHRProject;

public partial class EmployeeProfile
{
    public int Id { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}

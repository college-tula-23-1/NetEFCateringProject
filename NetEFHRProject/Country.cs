using System;
using System.Collections.Generic;

namespace NetEFHRProject;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CapitalId { get; set; }

    public virtual City? Capital { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}

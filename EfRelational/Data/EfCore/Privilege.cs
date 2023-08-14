using System;
using System.Collections.Generic;

namespace EfRelational.Data.EfCore;

public partial class Privilege
{
    public int Id { get; set; }

    public string? PrivilegeName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

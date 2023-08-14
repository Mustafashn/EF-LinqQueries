using System;
using System.Collections.Generic;

namespace EfRelational.Data.EfCore;

public partial class EmployeePerformance
{
    public int EmployeeId { get; set; }

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public int? SaleCount { get; set; }
}

using System;
using System.Collections.Generic;

namespace EfRelational.Data.EfCore;

public partial class Customers2
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Age { get; set; }

    public decimal? Salary { get; set; }
}

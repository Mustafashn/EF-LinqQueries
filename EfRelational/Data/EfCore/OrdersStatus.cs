using System;
using System.Collections.Generic;

namespace EfRelational.Data.EfCore;

public partial class OrdersStatus
{
    public sbyte Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

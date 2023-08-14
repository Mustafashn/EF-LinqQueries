using System;
using System.Collections.Generic;

namespace EfRelational.Data.EfCore;

public partial class Product
{
    public string? SupplierIds { get; set; }

    public int Id { get; set; }

    public string? ProductCode { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public decimal? StandardCost { get; set; }

    public decimal ListPrice { get; set; }

    public int? ReorderLevel { get; set; }

    public int? TargetLevel { get; set; }

    public string? QuantityPerUnit { get; set; }

    public bool Discontinued { get; set; }

    public int? MinimumReorderQuantity { get; set; }

    public string? Category { get; set; }

    public byte[]? Attachments { get; set; }

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();
}

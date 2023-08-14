using System;
using System.Collections.Generic;

namespace EfRelational.Data.EfCore;

public partial class PurchaseOrderDetail
{
    public int Id { get; set; }

    public int PurchaseOrderId { get; set; }

    public int? ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitCost { get; set; }

    public DateTime? DateReceived { get; set; }

    public bool PostedToInventory { get; set; }

    public int? InventoryId { get; set; }

    public virtual InventoryTransaction? Inventory { get; set; }

    public virtual Product? Product { get; set; }

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
}

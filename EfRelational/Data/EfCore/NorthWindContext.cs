using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfRelational.Data.EfCore;

public partial class NorthWindContext : DbContext
{
    public NorthWindContext()
    {
    }

    public NorthWindContext(DbContextOptions<NorthWindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Customers2> Customers2s { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeePerformance> EmployeePerformances { get; set; }

    public virtual DbSet<InventoryTransaction> InventoryTransactions { get; set; }

    public virtual DbSet<InventoryTransactionType> InventoryTransactionTypes { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderDetailsStatus> OrderDetailsStatuses { get; set; }

    public virtual DbSet<OrdersStatus> OrdersStatuses { get; set; }

    public virtual DbSet<OrdersTaxStatus> OrdersTaxStatuses { get; set; }

    public virtual DbSet<Privilege> Privileges { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

    public virtual DbSet<PurchaseOrderStatus> PurchaseOrderStatuses { get; set; }

    public virtual DbSet<SalesReport> SalesReports { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<String> Strings { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }
    public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder
        .UseLoggerFactory(MyLoggerFactory)
        .UseMySQL("server=localhost;port=3306;database=northwind;user=root;password=mysql1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.HasIndex(e => e.City, "city");

            entity.HasIndex(e => e.Company, "company");

            entity.HasIndex(e => e.FirstName, "first_name");

            entity.HasIndex(e => e.LastName, "last_name");

            entity.HasIndex(e => e.StateProvince, "state_province");

            entity.HasIndex(e => e.ZipPostalCode, "zip_postal_code");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Attachments).HasColumnName("attachments");
            entity.Property(e => e.BusinessPhone)
                .HasMaxLength(25)
                .HasColumnName("business_phone");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Company)
                .HasMaxLength(50)
                .HasColumnName("company");
            entity.Property(e => e.CountryRegion)
                .HasMaxLength(50)
                .HasColumnName("country_region");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .HasColumnName("email_address");
            entity.Property(e => e.FaxNumber)
                .HasMaxLength(25)
                .HasColumnName("fax_number");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(25)
                .HasColumnName("home_phone");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .HasColumnName("job_title");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(25)
                .HasColumnName("mobile_phone");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(50)
                .HasColumnName("state_province");
            entity.Property(e => e.WebPage).HasColumnName("web_page");
            entity.Property(e => e.ZipPostalCode)
                .HasMaxLength(15)
                .HasColumnName("zip_postal_code");
        });

        modelBuilder.Entity<Customers2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customers2");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age)
                .HasMaxLength(45)
                .HasColumnName("age");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Salary)
                .HasPrecision(10)
                .HasColumnName("salary");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.HasIndex(e => e.City, "city");

            entity.HasIndex(e => e.Company, "company");

            entity.HasIndex(e => e.FirstName, "first_name");

            entity.HasIndex(e => e.LastName, "last_name");

            entity.HasIndex(e => e.StateProvince, "state_province");

            entity.HasIndex(e => e.ZipPostalCode, "zip_postal_code");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Attachments).HasColumnName("attachments");
            entity.Property(e => e.BusinessPhone)
                .HasMaxLength(25)
                .HasColumnName("business_phone");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Company)
                .HasMaxLength(50)
                .HasColumnName("company");
            entity.Property(e => e.CountryRegion)
                .HasMaxLength(50)
                .HasColumnName("country_region");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .HasColumnName("email_address");
            entity.Property(e => e.FaxNumber)
                .HasMaxLength(25)
                .HasColumnName("fax_number");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(25)
                .HasColumnName("home_phone");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .HasColumnName("job_title");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(25)
                .HasColumnName("mobile_phone");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(50)
                .HasColumnName("state_province");
            entity.Property(e => e.WebPage).HasColumnName("web_page");
            entity.Property(e => e.ZipPostalCode)
                .HasMaxLength(15)
                .HasColumnName("zip_postal_code");

            entity.HasMany(d => d.Privileges).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeePrivilege",
                    r => r.HasOne<Privilege>().WithMany()
                        .HasForeignKey("PrivilegeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_employee_privileges_privileges1"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_employee_privileges_employees1"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "PrivilegeId").HasName("PRIMARY");
                        j.ToTable("employee_privileges");
                        j.HasIndex(new[] { "EmployeeId" }, "employee_id");
                        j.HasIndex(new[] { "PrivilegeId" }, "privilege_id");
                        j.HasIndex(new[] { "PrivilegeId" }, "privilege_id_2");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                        j.IndexerProperty<int>("PrivilegeId").HasColumnName("privilege_id");
                    });
        });

        modelBuilder.Entity<EmployeePerformance>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee_performance");

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.EmployeeId, "employee_id_UNIQUE").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(45)
                .HasColumnName("fullname");
            entity.Property(e => e.SaleCount).HasColumnName("sale_count");
        });

        modelBuilder.Entity<InventoryTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inventory_transactions");

            entity.HasIndex(e => e.CustomerOrderId, "customer_order_id");

            entity.HasIndex(e => e.CustomerOrderId, "customer_order_id_2");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.HasIndex(e => e.ProductId, "product_id_2");

            entity.HasIndex(e => e.PurchaseOrderId, "purchase_order_id");

            entity.HasIndex(e => e.PurchaseOrderId, "purchase_order_id_2");

            entity.HasIndex(e => e.TransactionType, "transaction_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .HasColumnName("comments");
            entity.Property(e => e.CustomerOrderId).HasColumnName("customer_order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.PurchaseOrderId).HasColumnName("purchase_order_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TransactionCreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("transaction_created_date");
            entity.Property(e => e.TransactionModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("transaction_modified_date");
            entity.Property(e => e.TransactionType).HasColumnName("transaction_type");

            entity.HasOne(d => d.CustomerOrder).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.CustomerOrderId)
                .HasConstraintName("fk_inventory_transactions_orders1");

            entity.HasOne(d => d.Product).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inventory_transactions_products1");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.PurchaseOrderId)
                .HasConstraintName("fk_inventory_transactions_purchase_orders1");

            entity.HasOne(d => d.TransactionTypeNavigation).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.TransactionType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inventory_transactions_inventory_transaction_types1");
        });

        modelBuilder.Entity<InventoryTransactionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inventory_transaction_types");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("invoices");

            entity.HasIndex(e => e.OrderId, "fk_invoices_orders1_idx");

            entity.HasIndex(e => e.Id, "id");

            entity.HasIndex(e => e.Id, "id_2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmountDue)
                .HasPrecision(19, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("amount_due");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("due_date");
            entity.Property(e => e.InvoiceDate)
                .HasColumnType("datetime")
                .HasColumnName("invoice_date");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Shipping)
                .HasPrecision(19, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("shipping");
            entity.Property(e => e.Tax)
                .HasPrecision(19, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("tax");

            entity.HasOne(d => d.Order).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("fk_invoices_orders1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.CustomerId, "customer_id");

            entity.HasIndex(e => e.CustomerId, "customer_id_2");

            entity.HasIndex(e => e.EmployeeId, "employee_id");

            entity.HasIndex(e => e.EmployeeId, "employee_id_2");

            entity.HasIndex(e => e.StatusId, "fk_orders_orders_status1");

            entity.HasIndex(e => e.Id, "id");

            entity.HasIndex(e => e.Id, "id_2");

            entity.HasIndex(e => e.Id, "id_3");

            entity.HasIndex(e => e.ShipZipPostalCode, "ship_zip_postal_code");

            entity.HasIndex(e => e.ShipperId, "shipper_id");

            entity.HasIndex(e => e.ShipperId, "shipper_id_2");

            entity.HasIndex(e => e.TaxStatusId, "tax_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.PaidDate)
                .HasColumnType("datetime")
                .HasColumnName("paid_date");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(50)
                .HasColumnName("payment_type");
            entity.Property(e => e.ShipAddress).HasColumnName("ship_address");
            entity.Property(e => e.ShipCity)
                .HasMaxLength(50)
                .HasColumnName("ship_city");
            entity.Property(e => e.ShipCountryRegion)
                .HasMaxLength(50)
                .HasColumnName("ship_country_region");
            entity.Property(e => e.ShipName)
                .HasMaxLength(50)
                .HasColumnName("ship_name");
            entity.Property(e => e.ShipStateProvince)
                .HasMaxLength(50)
                .HasColumnName("ship_state_province");
            entity.Property(e => e.ShipZipPostalCode)
                .HasMaxLength(50)
                .HasColumnName("ship_zip_postal_code");
            entity.Property(e => e.ShippedDate)
                .HasColumnType("datetime")
                .HasColumnName("shipped_date");
            entity.Property(e => e.ShipperId).HasColumnName("shipper_id");
            entity.Property(e => e.ShippingFee)
                .HasPrecision(19, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("shipping_fee");
            entity.Property(e => e.StatusId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("status_id");
            entity.Property(e => e.TaxRate)
                .HasDefaultValueSql("'0'")
                .HasColumnName("tax_rate");
            entity.Property(e => e.TaxStatusId).HasColumnName("tax_status_id");
            entity.Property(e => e.Taxes)
                .HasPrecision(19, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("taxes");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("fk_orders_customers");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("fk_orders_employees1");

            entity.HasOne(d => d.Shipper).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipperId)
                .HasConstraintName("fk_orders_shippers1");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("fk_orders_orders_status1");

            entity.HasOne(d => d.TaxStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TaxStatusId)
                .HasConstraintName("fk_orders_orders_tax_status1");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("order_details");

            entity.HasIndex(e => e.StatusId, "fk_order_details_order_details_status1_idx");

            entity.HasIndex(e => e.OrderId, "fk_order_details_orders1_idx");

            entity.HasIndex(e => e.Id, "id");

            entity.HasIndex(e => e.Id, "id_2");

            entity.HasIndex(e => e.Id, "id_3");

            entity.HasIndex(e => e.Id, "id_4");

            entity.HasIndex(e => e.Id, "id_5");

            entity.HasIndex(e => e.InventoryId, "inventory_id");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.HasIndex(e => e.ProductId, "product_id_2");

            entity.HasIndex(e => e.PurchaseOrderId, "purchase_order_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateAllocated)
                .HasColumnType("datetime")
                .HasColumnName("date_allocated");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.PurchaseOrderId).HasColumnName("purchase_order_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(19, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("unit_price");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_details_orders1");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_order_details_products1");

            entity.HasOne(d => d.Status).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("fk_order_details_order_details_status1");
        });

        modelBuilder.Entity<OrderDetailsStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("order_details_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<OrdersStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<OrdersTaxStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders_tax_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TaxStatusName)
                .HasMaxLength(50)
                .HasColumnName("tax_status_name");
        });

        modelBuilder.Entity<Privilege>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("privileges");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PrivilegeName)
                .HasMaxLength(50)
                .HasColumnName("privilege_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.ProductCode, "product_code");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attachments).HasColumnName("attachments");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Discontinued).HasColumnName("discontinued");
            entity.Property(e => e.ListPrice)
                .HasPrecision(19, 4)
                .HasColumnName("list_price");
            entity.Property(e => e.MinimumReorderQuantity).HasColumnName("minimum_reorder_quantity");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(25)
                .HasColumnName("product_code");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasColumnName("product_name");
            entity.Property(e => e.QuantityPerUnit)
                .HasMaxLength(50)
                .HasColumnName("quantity_per_unit");
            entity.Property(e => e.ReorderLevel).HasColumnName("reorder_level");
            entity.Property(e => e.StandardCost)
                .HasPrecision(19, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("standard_cost");
            entity.Property(e => e.SupplierIds).HasColumnName("supplier_ids");
            entity.Property(e => e.TargetLevel).HasColumnName("target_level");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("purchase_orders");

            entity.HasIndex(e => e.CreatedBy, "created_by");

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.HasIndex(e => e.Id, "id_2");

            entity.HasIndex(e => e.StatusId, "status_id");

            entity.HasIndex(e => e.SupplierId, "supplier_id");

            entity.HasIndex(e => e.SupplierId, "supplier_id_2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprovedBy).HasColumnName("approved_by");
            entity.Property(e => e.ApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("approved_date");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.ExpectedDate)
                .HasColumnType("datetime")
                .HasColumnName("expected_date");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PaymentAmount)
                .HasPrecision(19, 4)
                .HasDefaultValueSql("'0.0000'")
                .HasColumnName("payment_amount");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.ShippingFee)
                .HasPrecision(19, 4)
                .HasColumnName("shipping_fee");
            entity.Property(e => e.StatusId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("status_id");
            entity.Property(e => e.SubmittedBy).HasColumnName("submitted_by");
            entity.Property(e => e.SubmittedDate)
                .HasColumnType("datetime")
                .HasColumnName("submitted_date");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.Taxes)
                .HasPrecision(19, 4)
                .HasColumnName("taxes");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("fk_purchase_orders_employees1");

            entity.HasOne(d => d.Status).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("fk_purchase_orders_purchase_order_status1");

            entity.HasOne(d => d.Supplier).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("fk_purchase_orders_suppliers1");
        });

        modelBuilder.Entity<PurchaseOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("purchase_order_details");

            entity.HasIndex(e => e.Id, "id");

            entity.HasIndex(e => e.InventoryId, "inventory_id");

            entity.HasIndex(e => e.InventoryId, "inventory_id_2");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.HasIndex(e => e.ProductId, "product_id_2");

            entity.HasIndex(e => e.PurchaseOrderId, "purchase_order_id");

            entity.HasIndex(e => e.PurchaseOrderId, "purchase_order_id_2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateReceived)
                .HasColumnType("datetime")
                .HasColumnName("date_received");
            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");
            entity.Property(e => e.PostedToInventory).HasColumnName("posted_to_inventory");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.PurchaseOrderId).HasColumnName("purchase_order_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitCost)
                .HasPrecision(19, 4)
                .HasColumnName("unit_cost");

            entity.HasOne(d => d.Inventory).WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(d => d.InventoryId)
                .HasConstraintName("fk_purchase_order_details_inventory_transactions1");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_purchase_order_details_products1");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_purchase_order_details_purchase_orders1");
        });

        modelBuilder.Entity<PurchaseOrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("purchase_order_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        modelBuilder.Entity<SalesReport>(entity =>
        {
            entity.HasKey(e => e.GroupBy).HasName("PRIMARY");

            entity.ToTable("sales_reports");

            entity.Property(e => e.GroupBy)
                .HasMaxLength(50)
                .HasColumnName("group_by");
            entity.Property(e => e.Default).HasColumnName("default");
            entity.Property(e => e.Display)
                .HasMaxLength(50)
                .HasColumnName("display");
            entity.Property(e => e.FilterRowSource).HasColumnName("filter_row_source");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("shippers");

            entity.HasIndex(e => e.City, "city");

            entity.HasIndex(e => e.Company, "company");

            entity.HasIndex(e => e.FirstName, "first_name");

            entity.HasIndex(e => e.LastName, "last_name");

            entity.HasIndex(e => e.StateProvince, "state_province");

            entity.HasIndex(e => e.ZipPostalCode, "zip_postal_code");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Attachments).HasColumnName("attachments");
            entity.Property(e => e.BusinessPhone)
                .HasMaxLength(25)
                .HasColumnName("business_phone");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Company)
                .HasMaxLength(50)
                .HasColumnName("company");
            entity.Property(e => e.CountryRegion)
                .HasMaxLength(50)
                .HasColumnName("country_region");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .HasColumnName("email_address");
            entity.Property(e => e.FaxNumber)
                .HasMaxLength(25)
                .HasColumnName("fax_number");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(25)
                .HasColumnName("home_phone");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .HasColumnName("job_title");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(25)
                .HasColumnName("mobile_phone");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(50)
                .HasColumnName("state_province");
            entity.Property(e => e.WebPage).HasColumnName("web_page");
            entity.Property(e => e.ZipPostalCode)
                .HasMaxLength(15)
                .HasColumnName("zip_postal_code");
        });

        modelBuilder.Entity<String>(entity =>
        {
            entity.HasKey(e => e.StringId).HasName("PRIMARY");

            entity.ToTable("strings");

            entity.Property(e => e.StringId).HasColumnName("string_id");
            entity.Property(e => e.StringData)
                .HasMaxLength(255)
                .HasColumnName("string_data");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("suppliers");

            entity.HasIndex(e => e.City, "city");

            entity.HasIndex(e => e.Company, "company");

            entity.HasIndex(e => e.FirstName, "first_name");

            entity.HasIndex(e => e.LastName, "last_name");

            entity.HasIndex(e => e.StateProvince, "state_province");

            entity.HasIndex(e => e.ZipPostalCode, "zip_postal_code");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Attachments).HasColumnName("attachments");
            entity.Property(e => e.BusinessPhone)
                .HasMaxLength(25)
                .HasColumnName("business_phone");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Company)
                .HasMaxLength(50)
                .HasColumnName("company");
            entity.Property(e => e.CountryRegion)
                .HasMaxLength(50)
                .HasColumnName("country_region");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .HasColumnName("email_address");
            entity.Property(e => e.FaxNumber)
                .HasMaxLength(25)
                .HasColumnName("fax_number");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(25)
                .HasColumnName("home_phone");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .HasColumnName("job_title");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(25)
                .HasColumnName("mobile_phone");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(50)
                .HasColumnName("state_province");
            entity.Property(e => e.WebPage).HasColumnName("web_page");
            entity.Property(e => e.ZipPostalCode)
                .HasMaxLength(15)
                .HasColumnName("zip_postal_code");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

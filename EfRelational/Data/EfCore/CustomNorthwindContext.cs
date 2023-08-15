using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EfRelational.Data.EfCore
{
    public class CustomerOrder
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public int OrderCount { get; set; }


    }
    public class CustomNorthwindContext : NorthWindContext
    {
        public DbSet<CustomerOrder> CustomerOrders { get; set; }

        public CustomNorthwindContext()
        {

        }
        public CustomNorthwindContext(DbContextOptions<NorthWindContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
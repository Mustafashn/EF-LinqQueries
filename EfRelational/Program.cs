using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using EfRelational.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace EfRelational
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                        .UseLoggerFactory(MyLoggerFactory)
                        .UseMySQL(@"server=localhost;port=3306;database=ShopDb2;user=root;password=mysql1234;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

            modelBuilder.Entity<Customer>()
            .Property(p => p.IdentityNumber)
            .HasMaxLength(11)
            .IsRequired();

            modelBuilder.Entity<ProductCategory>()
            .HasKey(t => new { t.ProductId, t.CategoryId });

            modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
           .HasOne(pc => pc.Category)
           .WithMany(c => c.ProductCategories)
           .HasForeignKey(pc => pc.CategoryId);
        }
    }
    public static class DataSeeding
    {
        public static void Seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context is ShopContext)
                {
                    ShopContext _context = context as ShopContext;
                    if (_context.Products.Count() == 0)
                    {
                        _context.Products.AddRange(Products);
                    }
                    if (_context.Categories.Count() == 0)
                    {
                        _context.Categories.AddRange(Categories);
                    }
                }
            }
            context.SaveChanges();
        }
        private static Product[] Products = {
            new Product(){Name="Samsung S6",Price=2000},
            new Product(){Name="Samsung S7",Price=3000},
            new Product(){Name="Samsung S8",Price=4000},
            new Product(){Name="Samsung S9",Price=5000},
        };
        private static Category[] Categories = {
            new Category(){Name="Telefon"},
            new Category(){Name="Elektronik"},
            new Category(){Name="Bilgisayar"},
        };
    }
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5), MaxLength(15)]
        public string Username { get; set; }
        public string Email { get; set; }
        public Customer Customer { get; set; }
        public List<Address> Addresses { get; set; } //navigation property
    }
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
    }
    public class Address
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public User User { get; set; } //navigation property
        public int UserId { get; set; }

    }
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime InsertedDate { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdatedDate { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }

    }
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public required string Name { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new NorthWindContext())
            {
                //Get all customers
                var customers = db.Customers.ToList();
                foreach (var c in customers)
                {
                    Console.WriteLine($"Customer: {c.FirstName} {c.LastName}");
                }
                //Get all customers select first_name and last_name
                var customersSelect = db.Customers.Select(c => new
                {
                    c.FirstName,
                    c.LastName
                });
                //get customers order by name who lives in new york
                var customersInNewyork = db.Customers.Where(c => c.City == "New York").Select(c => new { c.FirstName, c.LastName }).OrderBy(c => c.FirstName);
                foreach (var c in customersInNewyork)
                {
                    Console.WriteLine($"Customer: {c.FirstName} {c.LastName}");
                }
                //get products name from beverages category
                var productNamesBeverages = db.Products.Where(c => c.Category == "Beverages").Select(c => c.ProductName).ToList();
                foreach (var name in productNamesBeverages)
                {
                    Console.WriteLine(name);
                }
                //get last added 5 products

                var productsLast = db.Products.OrderByDescending(i => i.Id).Select(c => c.ProductName).Take(5);
                foreach (var name in productsLast)
                {
                    Console.WriteLine(name);
                }
                //get product name,price which products price between 10-30
                var productsNamePriceList = db.Products.Where(p => p.ListPrice < 30 && p.ListPrice > 10).Select(p => new { p.ProductName, p.ListPrice }).OrderByDescending(i => i.ListPrice).ToList();
                foreach (var product in productsNamePriceList)
                {
                    Console.WriteLine($"{product.ProductName}: {product.ListPrice}");
                }

                //beverages category products average 
                var avg = db.Products.Where(p => p.Category == "Beverages").Average(i => i.ListPrice);
                Console.WriteLine("Average: " + avg);
                //beverages category product count
                var count = db.Products.Count(p => p.Category == "Beverages");
                Console.WriteLine("Total Count: " + count);
                //what are the beverages and condiments products total price
                var totalPrice = db.Products.Where(i => i.Category == "Beverages" || i.Category == "Condiments").Sum(i => i.ListPrice);
                Console.WriteLine("Total price :" + totalPrice);
                //get all products which are include tea
                var productsTea = db.Products.Where(i => i.ProductName.Contains("Tea") || i.Description.Contains("tea")).Select(i => i.ProductName);
                foreach (var item in productsTea)
                {
                    Console.WriteLine(item);
                }
                //most expensive and cheapest price
                var minPrice = db.Products.Min(i => i.ListPrice);
                var maxPrice = db.Products.Max(i => i.ListPrice);
                Console.WriteLine($"Expensive: {maxPrice}, Cheapest: {minPrice}");

                var cheapest = db.Products.Where(i => i.ListPrice == (db.Products.Min(a => a.ListPrice))).FirstOrDefault();
                Console.WriteLine("Cheapest product name: " + cheapest.ProductName);

            }

        }

        static void InsertUsers()
        {
            var users = new List<User>() {
                new User(){
                    Username="mustafasahin",Email="mustafashn@hotmail.com",
                },
                new User(){
                    Username="melikesahin",Email="melike@hotmail.com",
                },
                new User(){
                    Username="simgecengiz",Email="simgecengiz@gmail.com",
                },
                new User(){
                    Username="seyma",Email="seymamese@outlook.com",
                },
        };
            using (var db = new ShopContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }
        static void InsertAddresses()
        {
            var addresses = new List<Address>() {
                new Address(){
                    Fullname="Mustafa Sahin",Title="Ev Adresi",Body="Balıkesir",UserId=1
                },
                new Address(){
                    Fullname="Mustafa Sahin",Title="Iş Adresi",Body="Izmir",UserId=1
                },
                new Address(){
                    Fullname="Simge Cengiz",Title="Ev Adresi",Body="Aydın",UserId=3
                },
                new Address(){
                    Fullname="Simge Cengiz",Title="Iş Adresi",Body="Izmir",UserId=3
                },
            };
            using (var db = new ShopContext())
            {
                db.Addresses.AddRange(addresses);
                db.SaveChanges();
            }
        }
        static void InsertAddressWhereId(int id)
        {
            using (var db = new ShopContext())
            {
                var user = db.Users.FirstOrDefault(i => i.Id == id);

                if (user != null)
                {
                    user.Addresses.AddRange(
                        new List<Address>() {
                            new Address()
                        {
                            Fullname = "Melike Sahin",
                            Title = "Ev Adresi",
                            Body = "Tekirdağ",
                        },
                        new Address()
                        {
                            Fullname = "Melike Sahin",
                            Title = "Iş Adresi",
                            Body = "Tekirdağ",
                        },
                        }
                );
                }
                db.SaveChanges();
            }
        }
        static void InsertCustomer()
        {
            using (var db = new ShopContext())
            {
                var customer = new Customer()
                {
                    IdentityNumber = "1231231",
                    FirstName = "Mustafa",
                    LastName = "Sahin",
                    User = db.Users.FirstOrDefault(i => i.Id == 1),

                };
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }
        static void InsertUserWithCustomer()
        {
            using (var db = new ShopContext())
            {
                var user = new User()
                {
                    Username = "deneme",
                    Email = "deneme@gmail.com",
                    Customer = new Customer()
                    {
                        FirstName = "Deneme",
                        LastName = "Deneme",
                        IdentityNumber = "132123",
                    }
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        static void InsertProductCategories()
        {
            using (var db = new ShopContext())
            {
                var products = new List<Product>()
                {
                        new Product() {
                            Name="Samsung S5",
                            Price=2000,
                        },
                        new Product() {
                            Name="Samsung S6",
                            Price=3000,
                        },
                        new Product() {
                            Name="Samsung S7",
                            Price=4000,
                        },new Product() {
                            Name="Samsung S8",
                            Price=5000,
                        }
                };


                var categories = new List<Category>(){
                    new Category(){
                        Name="Telefon"
                    },
                    new Category(){
                        Name="Elektronik"
                    },
                    new Category(){
                        Name="Bilgisayar"
                    },
                };

                int[] ids = new int[2] { 1, 2 };
                var p = db.Products.Find(1);
                p.ProductCategories = ids.Select(cid => new ProductCategory()
                {
                    CategoryId = cid,
                    ProductId = p.Id,
                }).ToList();
                db.SaveChanges();
            }
        }
    }
}
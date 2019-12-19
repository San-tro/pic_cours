using Microsoft.EntityFrameworkCore;
using pis_c.Models.DBSeeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.Models.DBEntities
{
    public class AppDbContext : DbContext
    {
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<DaysDiscount> DaysDiscounts { get; set; }
        public DbSet<DriveType> DriveTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<GearBox> GearBoxes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersDiscount> OrdersDiscounts { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=CarRent; Trusted_connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(UserSeeder.Create(10));
            modelBuilder.Entity<OrdersDiscount>().HasData(OrdersDiscountSeeder.Create());
            modelBuilder.Entity<Brand>().HasData(BrandSeeder.Create());
            modelBuilder.Entity<Model>().HasData(ModelSeeder.Create());
            modelBuilder.Entity<DaysDiscount>().HasData(DaysDiscountSeeder.Create());
            modelBuilder.Entity<GearBox>().HasData(GearBoxSeeder.Create());
            modelBuilder.Entity<BodyType>().HasData(BodyTypeSeeder.Create());
            modelBuilder.Entity<CarClass>().HasData(CarClassSeeder.Create());
            modelBuilder.Entity<DriveType>().HasData(DriveTypeSeeder.Create());
            modelBuilder.Entity<FuelType>().HasData(FuelTypeSeeder.Create());
        }
    }
}

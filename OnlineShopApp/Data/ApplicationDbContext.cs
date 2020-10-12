using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShopApp.Models;

namespace OnlineShopApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<OnlineShopApp.Models.Division> Division { get; set; }
        public DbSet<OnlineShopApp.Models.District> District { get; set; }
        public DbSet<OnlineShopApp.Models.ThanaOrUpazila> ThanaOrUpazila { get; set; }
        public DbSet<OnlineShopApp.Models.PostOffice> PostOffice { get; set; }
        public DbSet<OnlineShopApp.Models.Address> Address { get; set; }
        public DbSet<OnlineShopApp.Models.BloodGroup> BloodGroup { get; set; }
        public DbSet<OnlineShopApp.Models.Gender> Gender { get; set; }
        public DbSet<OnlineShopApp.Models.Customer> Customer { get; set; }
        public DbSet<OnlineShopApp.Models.Employee> Employee { get; set; }
        public DbSet<OnlineShopApp.Models.EmpType> EmpType { get; set; }
        public DbSet<OnlineShopApp.Models.MaritalStatus> MaritalStatus { get; set; }
        public DbSet<OnlineShopApp.Models.MyColor> MyColor { get; set; }
        public DbSet<OnlineShopApp.Models.Product> Product { get; set; }
        public DbSet<OnlineShopApp.Models.MySize> MySize { get; set; }

    }
}

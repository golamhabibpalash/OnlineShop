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
    }
}

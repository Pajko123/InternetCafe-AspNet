using System;
using System.Collections.Generic;
using System.Text;
using InternetCafe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InternetCafe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<IRL> IRLs { get; set; }
        public DbSet<VIP> VIPs { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

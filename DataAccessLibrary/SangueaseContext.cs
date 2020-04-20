using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public class SangueaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=SangueaseDB;Integrated Security=True");
        }

        public DbSet<BloodDonationEvent> BloodDonationEvents { get; set; }
        public DbSet<BloodDonorInfo> BloodDonors { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<AchievementItem> Achievements { get; set; }
    }
}

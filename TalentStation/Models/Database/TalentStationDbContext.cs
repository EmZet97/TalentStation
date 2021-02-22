using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TalentStation.Models.Database.DbModels;

namespace TalentStation.Models.Database
{
    public class TalentStationDbContext : DbContext
    {
        public TalentStationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<PasswordDbModel> Passwords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

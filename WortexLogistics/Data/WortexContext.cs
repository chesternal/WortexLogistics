using WortexLogistics.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WortexLogistics.Data
{
    public partial class WortexContext : DbContext
    {
        public WortexContext()
        {
        }

        public WortexContext(DbContextOptions<WortexContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WarehouseCargo> WarehouseCargo { get; set; }
        public virtual DbSet<TruckCargo> TruckCargo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:wortexlogistics.database.windows.net,1433;Initial Catalog=wortexlogistics;Persist Security Info=False;User ID=wortex;Password=Parool123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
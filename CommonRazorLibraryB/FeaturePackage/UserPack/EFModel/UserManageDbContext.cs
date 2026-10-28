using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CommonRazorLibraryB.FeaturePackage.UserPack.EFModel
{
    public class UserManageDbContext : DbContext
    {
        public UserManageDbContext(DbContextOptions<UserManageDbContext> options) : base(options)
        {

        }

        public virtual DbSet<UserInfoTable> UserInfoTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfoTable>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.UserName).HasMaxLength(500);
                entity.Property(e => e.Account).HasMaxLength(500);

                entity.Property(e => e.Role).HasConversion<int>().IsRequired();

                entity.HasIndex(e => e.Account).IsUnique();
            });
        }
    }
}

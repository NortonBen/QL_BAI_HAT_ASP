using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace QuanLyBaiHat.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Database")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BaiHat> BaiHats { get; set; }
        public DbSet<TacGia> TacGias { get; set; }
        public DbSet<CaSi> CaSis { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Media> Media { get; set; }
    }
}
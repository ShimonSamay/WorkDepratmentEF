using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WorkDepratmentMisson.Models
{
    public partial class DeprtmentDB : DbContext
    {
        public DeprtmentDB()
            : base("name=DeprtmentDB")
        {
        }
        public virtual DbSet <Worker> Workers { get; set; }
        public virtual DbSet <Manager> Managers { get; set; }
        public virtual DbSet<HR> HR { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

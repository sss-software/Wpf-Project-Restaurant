using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BussinnesEntity;

namespace ProjectContext
{
    public class projectContext : DbContext
    {
        public projectContext(string connectionString)
            : base(connectionString)
        {

        }
        public projectContext()
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Ration> Rations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>().HasKey(t => new { t.TableId });
            modelBuilder.Entity<Order>().HasKey(o => new { o.OrderID });
            modelBuilder.Entity<Person>().HasKey(p => new { p.PersonId });
            modelBuilder.Entity<Ration>().HasKey(r => new { r.RationId });
        }
    }
}

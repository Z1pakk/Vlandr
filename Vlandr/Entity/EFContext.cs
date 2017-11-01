using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vlandr.Entity
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DatabaseConnection") { }
        public DbSet<User> Users { get; set; }
    }
}





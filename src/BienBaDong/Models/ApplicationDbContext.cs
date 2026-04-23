using System.Collections.Generic;
using System.Data.Entity;

namespace BienBaDong.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=BaDongConn")
        {
        }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<AdminAccount> AdminAccounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
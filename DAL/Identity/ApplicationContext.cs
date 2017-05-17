using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Identity.Entities;

namespace DAL.Identity
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace KEnergy.WebUI.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }


    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Manager> Managers { get; set; }
    }
}
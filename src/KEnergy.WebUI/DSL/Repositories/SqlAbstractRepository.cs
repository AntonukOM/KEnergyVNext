using KEnergy.WebUI.Models;
using Microsoft.Data.Entity.Infrastructure;

namespace KEnergy.WebUI.DSL.Repositories
{
    public class SqlAbstractRepository
    {
        protected ApplicationDbContext Context { get; } = new ApplicationDbContext();
    }
}
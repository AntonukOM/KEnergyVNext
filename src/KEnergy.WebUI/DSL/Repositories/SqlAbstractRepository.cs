using KEnergy.WebUI.Models;

namespace KEnergy.WebUI.DSL.Repositories
{
    public class SqlAbstractRepository
    {
        protected ApplicationDbContext Context { get; } = new ApplicationDbContext();
    }
}
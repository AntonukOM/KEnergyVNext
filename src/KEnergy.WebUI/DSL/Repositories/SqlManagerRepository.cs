using System.Collections.Generic;
using KEnergy.WebUI.DSL.Interfaces;
using KEnergy.WebUI.Models;

namespace KEnergy.WebUI.DSL.Repositories
{
    public class SqlManagerRepository : AbstractSqlRepository, IManagerRepository
    {
        public SqlManagerRepository(ApplicationDbContext context) : base(context) { }
        public IEnumerable<Manager> Managers => _context.Managers;
    }
}
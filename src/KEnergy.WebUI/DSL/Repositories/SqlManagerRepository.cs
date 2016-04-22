using System.Collections.Generic;
using KEnergy.WebUI.DSL.Interfaces;
using KEnergy.WebUI.Models;

namespace KEnergy.WebUI.DSL.Repositories
{
    public class SqlManagerRepository : SqlAbstractRepository, IManagerRepository
    {
        public SqlManagerRepository() : base() { }

        public IEnumerable<Manager> Managers
        {
            get { return Context.Managers; }
        }
    }
}
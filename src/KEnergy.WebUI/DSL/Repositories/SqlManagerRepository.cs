using System.Collections.Generic;
using KEnergy.WebUI.DSL.Interfaces;
using KEnergy.WebUI.Models;
using Microsoft.Data.Entity.Infrastructure;

namespace KEnergy.WebUI.DSL.Repositories
{
    public class SqlManagerRepository : SqlAbstractRepository, IManagerRepository
    {
        public IEnumerable<Manager> Managers
        {
            get { return Context.Managers; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KEnergy.WebUI.Models;

namespace KEnergy.WebUI.DSL.Repositories
{
    public abstract class AbstractSqlRepository
    {
        protected ApplicationDbContext _context;
        public AbstractSqlRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
    }
}

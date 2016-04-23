using System.Collections.Generic;
using KEnergy.WebUI.Models;
using Microsoft.AspNet.Mvc.Rendering;

namespace KEnergy.WebUI.Helpers.UI
{
    public class ManagerSelectList
    {
        private readonly IApplicationDbContext _context;

        public ManagerSelectList(IApplicationDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<SelectListItem> ManagerList
        {
            get
            {
                foreach (var m in _context.Managers)
                {
                    yield return new SelectListItem
                    {
                        Text = m.FullName,
                        Value = (m.ManagerId).ToString()
                    };
                }
            }
        }
    }
}
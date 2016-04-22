using System.Collections.Generic;
using KEnergy.WebUI.DSL.Interfaces;
using Microsoft.AspNet.Mvc.Rendering;

namespace KEnergy.WebUI.Helpers.UI_Elements
{
    public class ManagerSelectList
    {
        private IManagerRepository _repository;
        public ManagerSelectList(IManagerRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<SelectListItem> ManagerList
        {
            get
            {
                foreach (var m in _repository.Managers)
                {
                    yield return new SelectListItem
                    {
                        Text = m.FullName, Value = (m.ManagerId).ToString()
                    };
                }
            }
           
        }
    }
}
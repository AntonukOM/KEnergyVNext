using System.Collections.Generic;
using KEnergy.WebUI.Models;

namespace KEnergy.WebUI.DSL.Interfaces
{
    public interface IManagerRepository
    {
        IEnumerable<Manager> Managers { get; }
    }
}

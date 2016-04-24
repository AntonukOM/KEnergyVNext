using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KEnergy.WebUI.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }

        [Required(ErrorMessage = "Manager name is empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Manager surname is empty")]
        public string Surname { get; set; }

        [NotMapped]
        public string FullName => $"{Name} {Surname}";
    }
}
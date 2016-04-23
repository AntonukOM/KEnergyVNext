using System.ComponentModel.DataAnnotations;

namespace KEnergy.WebUI.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }

        [Required(ErrorMessage = "Manager name is empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Manager surname is empty")]
        public string Surname { get; set; }

        public string FullName
        {
            get
            {
                return $"{Name} {Surname}";
            }
            set
            {
                value = $"{Name} {Surname}";
            }
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KEnergy.WebUI.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Order name is empty")]
        public string Number { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ShipmentDate { get; set; }

        public string Note { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
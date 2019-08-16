using System;
using System.ComponentModel.DataAnnotations;

namespace VenteProduit.Models
{
    public class Achat
    {
        [Key]
        public long AchatId { get; set; }
        [Required]
        public long ClientID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAchat { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace VenteProduit.Models
{
    public class Facturation
    {
        [Key]
        public long FacturationId { get; set; }
        [Required]
        public long AchatId { get; set; }
        public decimal PrixTotal { get; set; }
        public Achat Achat { get; set; }
    }
}

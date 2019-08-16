using System;
using System.ComponentModel.DataAnnotations;

namespace VenteProduit.Models
{
    public class Client
    {
        [Key]
        public long ClientId { get; set; }
        [Required(ErrorMessage="Le nom est obligatoire")]
        public string ClientName { get; set; }
        public Vente Vente { get; set; }
    }
}

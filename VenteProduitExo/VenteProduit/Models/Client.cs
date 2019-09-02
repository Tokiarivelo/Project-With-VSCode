using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VenteProduit.Models
{
    public class Client
    {
        [Key]
        public long ClientId { get; set; }
        [Required(ErrorMessage="Le nom est obligatoire"), Display(Name = "Nom")]
        public string ClientName { get; set; }
        [Display(Name = "Prénom")]
        public string ClientPrenom { get; set; }
        public List<Achat> Achats { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VenteProduit.Models
{
    public class Achat
    {
        [Key]
        public long AchatId { get; set; }
        [Required(ErrorMessage="Le nomm est réquis")]
        public long ClientID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAchat { get; set; }
        public Facturation Facture { get; set; }
        public Client  Clients { get; set; }
        public List<Vente>  Ventes { get; set; }
    }
}

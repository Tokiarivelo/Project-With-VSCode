using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VenteProduit.Models
{
    public class Vente
    {
        [Key]
        public long VenteId { get; set; }
        [Required]
        public long ProduitId { get; set; }
        [Required]
        public long AchatId { get; set; }
        public long Quantite { get; set; }
        public Achat Achats { get; set; }
        public Produit Produit { get; set; }

    }
}

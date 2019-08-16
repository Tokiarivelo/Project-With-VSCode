using System;
using System.ComponentModel.DataAnnotations;

namespace VenteProduit.Models
{
    public class Produit
    {
        [Key]
        public long ProduitId { get; set; }
        [Required(ErrorMessage = "Le nom du produit est obligatoire")]
        public string ProduitName { get; set; }
        [Required(ErrorMessage = "Il faut un prix pour un produit")]
        public decimal PrixUnitaire { get; set; }
    }
}

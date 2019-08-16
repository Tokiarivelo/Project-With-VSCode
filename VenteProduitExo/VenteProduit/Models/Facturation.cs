using System;
using System.ComponentModel.DataAnnotations;

namespace VenteProduit.Models
{
    public class Facturation
    {
        [Key]
        public long FacturationId { get; set; }
        
    }
}

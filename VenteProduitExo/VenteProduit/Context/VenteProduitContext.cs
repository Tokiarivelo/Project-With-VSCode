using System;
using Microsoft.EntityFrameworkCore;
using VenteProduit.Models;

namespace VenteProduit.Context
{
    public class VenteProduitContext : DbContext
    {
        public VenteProduitContext(DbContextOptions<VenteProduitContext> options) : base(options){}
        public DbSet<Produit> Produit { get; set; }
        public DbSet<Vente> Vente { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Facturation> Facturation { get; set; }
        public DbSet<VenteProduit.Models.Achat> Achat { get; set; }
    }
}

using CambioDivisas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CambioDivisas.DAL
{
    public class CambioDivisasContext: DbContext
    {
        public CambioDivisasContext() : base("CambioDivisasContext")
        { }

        public DbSet<Rates> Rates { get; set; }
        public DbSet<Transacciones> Transacciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<CambioDivisas.Models.ViewModel.ListadoSkuVM> ListadoSkuVMs { get; set; }
    }
}
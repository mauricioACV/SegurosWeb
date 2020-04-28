using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Seguros.Web.FrontEnd.Models
{
    public class SegurosDbContext : DbContext
    {            
        public SegurosDbContext()
            : base("conexionDb")//aqui va la conexion BD del web.config
        {

        }

        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Comuna> Comuna { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Observacion_req> Observacion_req { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Requerimiento> Requerimiento { get; set; }
        public DbSet<Rol> Rol { get; set; }
        
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            //para relacionar tablas despues
        //}

    }
}
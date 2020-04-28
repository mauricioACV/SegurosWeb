using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Seguros.Web.FrontEnd.Models
{
    using System;


    [Table("Requerimiento")]
    public class Requerimiento
    {
        public int Id { get; set; }
                                
        public DateTime Fecha_req { get; set; }
                                
        public DateTime Fecha_limit_req { get; set; }
                      
        public DateTime Fecha_fin_real { get; set; }

        public int Id_estado { get; set; }

        public int Id_cliente { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Seguros.Web.FrontEnd.Models
{


    [Table("Estado")]
    public class Estado
    {
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Seguros.Web.FrontEnd.Models
{
    [Table("Region")]
    public class Region
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Nombre_region { get; set; }

        public List<Ciudad> ciudades { get; set; }


    }
}
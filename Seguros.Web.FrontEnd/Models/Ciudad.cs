using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Seguros.Web.FrontEnd.Models
{
    [Table("Ciudad")]
    public class Ciudad
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Nombre_ciudad { get; set; }

        public Region region { get; set; }

        public List<Comuna> comunas { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seguros.Web.FrontEnd.Models
{
    public class Region
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Nombre_region { get; set; }

        public string Nombre_capital { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Seguros.Web.FrontEnd.Models
{
    [Table("Rut")]
    public class Rut
    {
        
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ingrese Rut Cliente")]
        public int Usuario_rut { get; set; }
    }
}
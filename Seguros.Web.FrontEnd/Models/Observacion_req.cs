using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seguros.Web.FrontEnd.Models
{
    public class Observacion_req
    {
        [Key]
        public int Id_observacion { get; set; }

        [Required]
        [StringLength(300)]
        public string Descripcion_obs { get; set; }

        public int Id_deptoEmpresa { get; set; }

        public int Id_rutEmpleado { get; set; }

        public int Id_requerimiento { get; set; }
    }
}
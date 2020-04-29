using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Seguros.Web.FrontEnd.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        [Key]
        public int Id_empleado { get; set; }

        [Display(Name = "Rut")]
        public int Rut_empleado { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        public string ApellidoPat { get; set; }

        [Display(Name = "Apellido Materno")]
        public string ApellidoMat { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime Fecha_nacimiento { get; set; }

        public string Calle { get; set; }

        [Display(Name = "Número")]
        public int NumCalle { get; set; }

        public string Comuna { get; set; }

        public string Ciudad { get; set; }

        [Display(Name = "Región")]
        public string Region { get; set; }

        public int Telefono { get; set; }

        public string Email { get; set; }

        public int Rol { get; set; }
    }
}
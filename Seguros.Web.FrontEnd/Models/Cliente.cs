using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Seguros.Web.FrontEnd.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int Id_cliente { get; set; }

        [Display(Name = "Rut")]
        public int Rut_cliente { get; set; }

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

        public Comuna comuna { get; set; }

        public Ciudad ciudad { get; set; }

        [Display(Name = "Región")]
        public Region Region { get; set; }

        public int Telefono { get; set; }

        public string Email { get; set; }

        [Display(Name = "Operación")]
        public string Operacion { get; set; }

        public string Estado { get; set; }

        [Required]
        [StringLength(300)]
        public string Observaciones { get; set; }

        public List<Requerimiento> Requerimientos { get; set; }

    }
}
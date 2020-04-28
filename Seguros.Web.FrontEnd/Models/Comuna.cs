﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seguros.Web.FrontEnd.Models
{
    public class Comuna
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Nombre_comuna { get; set; }

        public int Id_ciudad { get; set; }
    }
}
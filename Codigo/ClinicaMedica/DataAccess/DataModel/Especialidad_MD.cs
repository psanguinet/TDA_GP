﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    [MetadataType(typeof(Especialidad_MD))]
    public partial class Especialidad
    { }
    public class Especialidad_MD
    {
        [Required(ErrorMessage = "La especialidad es requerida.")]
        public int EspecialidadID { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Activo")]
        public bool Active { get; set; }
    }
}

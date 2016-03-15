using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class ResultadoAnalisis
    {
        [Key]
        public int ResultadoAnalisisID { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [Display(Name = "Nombre")]
        public string Nobmre { get; set; }

        [Required(ErrorMessage = "El resultado es requerido.")]
        public string Resultado { get; set; }
    }
}

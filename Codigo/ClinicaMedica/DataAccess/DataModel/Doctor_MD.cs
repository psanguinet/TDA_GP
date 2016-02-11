using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    [MetadataType(typeof(Doctor_MD))]
    public partial class Doctor
    { }

    public class Doctor_MD
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El apellido es requerido.")]
        public string Apellido { get; set; }
        public string CI { get; set; }
        public byte[] Foto { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Valor de Consulta")]
        public Nullable<decimal> ValorConsulta { get; set; }

        [Display(Name = "Sueldo Mínimo")]
        public Nullable<decimal> SueldoMinimo { get; set; }
        [Display(Name = "Es Director ?")]
        public bool IsDirector { get; set; }
               
        [Display(Name = "Activo ?")]
        public bool Active { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La cédula es requerida.")]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        public byte[] Foto { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El valor de la consulta es requerido.")]
        [Display(Name = "Valor Consulta")]
        public decimal ValorConsulta { get; set; }

        [Display(Name = "Es Director")]
        public bool EsDirector { get; set; }

        [Required(ErrorMessage = "El sueldo mínimo es requerido.")]
        [Display(Name = "Sueldo Mínimo")]
        public decimal SueldoMinimo { get; set; }

        public bool Activo { get; set; }

        public virtual User Usuario { get; set; }
        public virtual ICollection<Especialidad> ListEspecialidades { get; set; }


    }
}

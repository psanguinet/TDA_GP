using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class Paciente
    {
        [Key]
        public int PacienteID { get; set; }

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

        [Required(ErrorMessage = "La fecha de nacimento es requerida")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        public int Altura { get; set; }

        [Display(Name="Grupo Sanguíneo")]
        public string GrupoSanguineo { get; set; }
        public int Peso { get; set; }
        public virtual HistoriaMedica HistoriaMedica { get; set; }

        public virtual User Usuario { get; set; }
    }
}

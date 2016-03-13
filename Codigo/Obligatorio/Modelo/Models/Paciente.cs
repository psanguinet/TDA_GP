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
        [MaxLength(9, ErrorMessage = "La mayor cantidad de dígitos son {1}")]
        public string Cedula { get; set; }

        public byte[] Foto { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(10,ErrorMessage="La mayor cantidad de dígitos son {1}")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La fecha de nacimento es requerida")]
        [DataType(DataType.Date,ErrorMessage="El formato de la fecha debe ser dd/mm/yyyy")]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Altura (cm)")]
        [Range(0, 300,ErrorMessage="La alturar debe ser entre {1} y {2}")]
        [Required(ErrorMessage = "La altura es requerida")]
        public int Altura { get; set; }

        [Display(Name = "Grupo Sanguíneo")]
        public string GrupoSanguineo { get; set; }

        [Display(Name = "Peso (kg)")]
        [Range(0,500,ErrorMessage="El peso debe ser entre {1} y {2}")]
        [Required(ErrorMessage = "El peso es requerido")]
        public int Peso { get; set; }

        public bool Activo { get; set; }
      
        public virtual User Usuario { get; set; }
    }
}

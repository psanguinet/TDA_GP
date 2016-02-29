using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Models
{
    public class Especialidad
    {
        [Key]
        public  int EspecilidadID { get; set; }

        [Required(ErrorMessage = "El nombre de la especialidad es requeridad.")]
        public  string Nombre { get; set; }

        public virtual ICollection<Doctor> ListDoctores { get; set; }
    }
}

using System;
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
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Active { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    [MetadataType(typeof(Usuario_MD))]
    public partial class Usuario
    {
    }
    public class Usuario_MD
    {
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El usuario es requerido.")]
        public string UserName { get; set; }

        [Display(Name = "Contrasena")]
        [Required(ErrorMessage = "La contrasena es requerida.")]
        public string Password { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "El mail es requerido.")]
        [EmailAddress(ErrorMessage = "Debe ingresar un mail válido.")]
        public string Mail { get; set; }

        [Display(Name = "Activo")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "El rol es requerido.")]
        public Nullable<int> RolID { get; set; }
    }
}

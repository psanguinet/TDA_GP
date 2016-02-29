using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Models
{
    public class Role
    {
        [Key]
        public virtual Guid RoleId { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El nombre del rol es requerido.")]
        public virtual string RoleName { get; set; }

        [Display(Name = "Descripción")]
        public virtual string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
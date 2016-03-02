using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Models
{
    public class User
    {
        [Key]
        public virtual Guid UserId { get; set; }

        [Required(ErrorMessage="El nombre de usuario es requerido")]
        [Display(Name = "Usuario")]
        public virtual String Username { get; set; }

        [EmailAddress(ErrorMessage = "El formato no es correcto")]
        public virtual String Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required, DataType(DataType.Password)]
        public virtual String Password { get; set; }

        public virtual String FirstName { get; set; }
        public virtual String LastName { get; set; }

        [DataType(DataType.MultilineText)]
        public virtual String Comment { get; set; }

        public virtual Boolean IsApproved { get; set; }
        public virtual int PasswordFailuresSinceLastSuccess { get; set; }
        public virtual DateTime? LastPasswordFailureDate { get; set; }
        public virtual DateTime? LastActivityDate { get; set; }
        public virtual DateTime? LastLockoutDate { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual String ConfirmationToken { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual Boolean IsLockedOut { get; set; }
        public virtual DateTime? LastPasswordChangedDate { get; set; }
        public virtual String PasswordVerificationToken { get; set; }
        public virtual DateTime? PasswordVerificationTokenExpirationDate { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
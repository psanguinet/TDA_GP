using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modelo.Models
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Cedula { get; set; }
        public byte[] Foto { get; set; }
        public string Direccion { get; set; }
        
        public string  Telefono { get; set; }

        public int UsuarioID { get; set; }
        public virtual User Usuario { get; set; }
    }
}
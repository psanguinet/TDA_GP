using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Model;

namespace WebClinicaMedica.Models
{
    public class VM_Especialidad
    {
        public Especialidad Especialidad { get; set; }
        public bool Activa { get; set; }
    }
}
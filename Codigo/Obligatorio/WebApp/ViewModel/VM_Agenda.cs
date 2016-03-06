using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModel
{
    public class VM_Agenda
    {
        public Agenda Agenda { get; set; }
        public int PacienteID { get; set; }
        public int MedicoID { get; set; }
    }
}
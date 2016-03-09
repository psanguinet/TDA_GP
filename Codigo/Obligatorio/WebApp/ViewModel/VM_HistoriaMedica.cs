using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModel
{
    public class VM_HistoriaMedica
    {
        public IEnumerable<AnalisisClinico> ListadoInformesAnalisisClinicos { get; set; }
        public IEnumerable<InformesDeConsulta> ListadoInformeDeConsultas { get; set; }

        public VM_HistoriaMedica()
        {
            ListadoInformesAnalisisClinicos = new List<AnalisisClinico>();
            ListadoInformeDeConsultas = new List<InformesDeConsulta>();
        }
    }
}
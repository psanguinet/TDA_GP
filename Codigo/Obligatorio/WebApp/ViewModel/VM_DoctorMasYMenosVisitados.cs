using Modelo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.ViewModel
{
    public class VM_DoctorMasYMenosVisitados
    {
        public IDictionary<Doctor,int> DoctorMasVisitado { get; set; }

        public IDictionary<Doctor, int> DoctorMenosVisitado { get; set; }
     

        [Required(ErrorMessage = "La fecha es requerida.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha desde:")]
        public DateTime DateFrom { get; set; }


        [Required(ErrorMessage = "La fecha es requerida.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha hasta:")]
        public DateTime DateTo { get; set; }

        public VM_DoctorMasYMenosVisitados()
        {
            DoctorMasVisitado = new Dictionary<Doctor, int>();
            DoctorMenosVisitado = new Dictionary<Doctor, int>();
        }
    }
}
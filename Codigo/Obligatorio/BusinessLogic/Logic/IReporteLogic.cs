using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public interface IReporteLogic : IDisposable
    {
        IDictionary<Doctor, int> DoctorMasVisitado(DateTime dateFrom, DateTime dateTo);

        IDictionary<Doctor, int> DoctorMenosVisitado(DateTime dateFrom, DateTime dateTo);

        IDictionary<Doctor, int> ListadoNumeroDeConsultasMensuales(DateTime dateFrom, DateTime dateTo);
      
    }
}

using DataAccess.Model;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class ReporteLogic : IReporteLogic
    {
        public IDictionary<Doctor, int> DoctorMasVisitado(DateTime dateFrom, DateTime dateTo)
        {
            IDictionary<Doctor, int> result = new Dictionary<Doctor, int>();
            Doctor doctor = null;
            try
            {
                using (Context db = new Context())
                {
                    int doctorID = ListadoNumeroDeConsultasMensuales(dateFrom, dateTo).OrderByDescending(lc => lc.Value).First().Key;

                    doctor = db.Doctores.SingleOrDefault(d => d.DoctorID == doctorID);
                    int cantidad = ListadoNumeroDeConsultasMensuales(dateFrom, dateTo).OrderByDescending(lc => lc.Value).First().Value;
                    result.Add(doctor, cantidad);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return result;
        }

        public IDictionary<Doctor, int> DoctorMenosVisitado(DateTime dateFrom, DateTime dateTo)
        {
            IDictionary<Doctor, int> result = new Dictionary<Doctor, int>();
            Doctor doctor = null;
            try
            {
                using (Context db = new Context())
                {
                    int doctorID = ListadoNumeroDeConsultasMensuales(dateFrom, dateTo).OrderBy(lc => lc.Value).First().Key;
                    doctor = db.Doctores.SingleOrDefault(d => d.DoctorID == doctorID);
                    int cantidad = ListadoNumeroDeConsultasMensuales(dateFrom, dateTo).OrderBy(lc => lc.Value).First().Value;
                    result.Add(doctor, cantidad);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return result;
        }

        public IDictionary<int, int> ListadoNumeroDeConsultasMensuales(DateTime dateFrom, DateTime dateTo)
        {
            IDictionary<int, int> result = new Dictionary<int, int>();
            try
            {
                using (Context db = new Context())
                {
                    DateTime _dateFrom = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day);
                    DateTime _dateTo = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day);
                    _dateTo = dateTo.AddDays(1).AddSeconds(-1);
                    List<InformesDeConsulta> listaInformeDeConsutas = db.InformesDeConsultas.Where(ic => ic.Fecha >= _dateFrom && ic.Fecha <= _dateTo).ToList();

                    var results = listaInformeDeConsutas.GroupBy(ic => ic.Doctor.DoctorID).ToList();

                    foreach (var item in results)
                    {

                        result.Add(item.Key, listaInformeDeConsutas.Count(ic => ic.Doctor.DoctorID == item.Key));
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return result;
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}

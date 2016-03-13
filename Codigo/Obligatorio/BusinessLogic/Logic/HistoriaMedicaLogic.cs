using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class HistoriaMedicaLogic : IHistoriaMedicaLogic
    {
        public IEnumerable<Modelo.Models.HistoriaMedica> ListadoHistoriaMedica(Modelo.Models.Paciente paciente, string searchText)
        {
            IEnumerable<Modelo.Models.HistoriaMedica> result = new List<Modelo.Models.HistoriaMedica>();
            IEnumerable<InformesDeConsulta> listInformeConsulta = new List<InformesDeConsulta>();
            IEnumerable<AnalisisClinico> listAnalisisClinico = new List<AnalisisClinico>();

            try
            {
                DateTime myDate;
                if (!DateTime.TryParse(searchText, out myDate))//Selector fecha o texto
                {
                    #region TEXTO
                    using (IInformeDeConsultaLogic ic = new InformeDeConsultaLogic())
                    {
                        listInformeConsulta = ic.ListInformeDeConsultas(paciente).Where(i => i.Detalle.Contains(searchText));
                    }
                    using (IAnalisisClinicosLogic ac = new AnalisisClinicosLogic())
                    {
                        listAnalisisClinico = ac.ListadoInformesAnalisisClinicos(paciente).Where(i => i.Detalle.Contains(searchText));
                    }
                    #endregion
                }
                else
                {
                    #region FECHA
                    using (IInformeDeConsultaLogic ic = new InformeDeConsultaLogic())
                    {
                        listInformeConsulta = ic.ListInformeDeConsultas(paciente).Where(i => i.Fecha.Year == myDate.Year && i.Fecha.Month == myDate.Month && i.Fecha.Day == myDate.Day);
                    }
                    using (IAnalisisClinicosLogic ac = new AnalisisClinicosLogic())
                    {
                        listAnalisisClinico = ac.ListadoInformesAnalisisClinicos(paciente).Where(i => i.Fecha.Year == myDate.Year && i.Fecha.Month == myDate.Month && i.Fecha.Day == myDate.Day);
                    }
                    #endregion
                }
                result = MergeInformeConsulta_AnalisisClinico(listInformeConsulta, listAnalisisClinico);
            }
            catch (Exception e)
            {

                throw;
            }
            return result;
        }

        public IEnumerable<Modelo.Models.HistoriaMedica> ListadoHistoriaMedica(Modelo.Models.Doctor doctor, string searchText)
        {
            IEnumerable<Modelo.Models.HistoriaMedica> result = new List<Modelo.Models.HistoriaMedica>();
            IEnumerable<InformesDeConsulta> listInformeConsulta = new List<InformesDeConsulta>();
            IEnumerable<AnalisisClinico> listAnalisisClinico = new List<AnalisisClinico>();

            try
            {
                DateTime myDate;
                if (!DateTime.TryParse(searchText, out myDate))//Selector fecha o texto
                {
                    #region TEXTO
                    using (IInformeDeConsultaLogic ic = new InformeDeConsultaLogic())
                    {
                        listInformeConsulta = ic.ListInformeDeConsultas(doctor).Where(i => i.Detalle.Contains(searchText));
                    }
                    using (IAnalisisClinicosLogic ac = new AnalisisClinicosLogic())
                    {
                        listAnalisisClinico = ac.ListadoInformesAnalisisClinicos(doctor).Where(i => i.Detalle.Contains(searchText));
                    }
                    #endregion
                }
                else
                {
                    #region FECHA
                    using (IInformeDeConsultaLogic ic = new InformeDeConsultaLogic())
                    {
                        listInformeConsulta = ic.ListInformeDeConsultas(doctor).Where(i => i.Fecha.Year == myDate.Year && i.Fecha.Month == myDate.Month && i.Fecha.Day == myDate.Day);
                    }
                    using (IAnalisisClinicosLogic ac = new AnalisisClinicosLogic())
                    {
                        listAnalisisClinico = ac.ListadoInformesAnalisisClinicos(doctor).Where(i => i.Fecha.Year == myDate.Year && i.Fecha.Month == myDate.Month && i.Fecha.Day == myDate.Day);
                    }
                    #endregion
                }
                result = MergeInformeConsulta_AnalisisClinico(listInformeConsulta, listAnalisisClinico);

            }
            catch (Exception e)
            {

                throw;
            }
            return result;
        }

        private IEnumerable<Modelo.Models.HistoriaMedica> MergeInformeConsulta_AnalisisClinico(IEnumerable<InformesDeConsulta> listInformeConsulta, IEnumerable<AnalisisClinico> listAnalisisClinico)
        {
            List<Modelo.Models.HistoriaMedica> result = new List<Modelo.Models.HistoriaMedica>();
            try
            {
                HistoriaMedica element = null;
                foreach (var item in listInformeConsulta)
                {
                    element = new HistoriaMedica()
                    {
                        Numero = item.InformesDeConsultaID,
                        FechaCreacion = item.Fecha,
                        TipoDeInforme = EnumTipoDeInforme.InformesDeConsultas,
                        TipoDeInformeNombre = "Informe de Consulta"
                    };
                    result.Add(element);
                }
                foreach (var item in listAnalisisClinico)
                {
                    element = new HistoriaMedica()
                    {
                        Numero = item.AnalisisClinicoID,
                        FechaCreacion = item.Fecha,
                        TipoDeInforme = EnumTipoDeInforme.AnalisisCinico,
                        TipoDeInformeNombre = "Análisis Clínico"
                    };
                    result.Add(element);
                }

            }
            catch (Exception)
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

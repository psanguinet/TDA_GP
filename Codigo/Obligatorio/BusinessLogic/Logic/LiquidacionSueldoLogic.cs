using DataAccess.Model;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BusinessLogic.Logic
{
    public class LiquidacionSueldoLogic : ILiquidacionSueldoLogic
    {

        public IEnumerable<Modelo.Models.LiquidacionDeSueldo> GetLiquidacionesDelMesYAnio(int mes, int anio)
        {
            IEnumerable<LiquidacionDeSueldo> result = new List<LiquidacionDeSueldo>();
            try
            {
             
                using (Context db = new Context())
                {
                    result = db.LiquidacionesDeSueldos.Include("Doctor").Where(ls => ls.Anio == anio && ls.Mes == mes).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }


        public void HacerLiquidacionesDelMesYAnio(int mes, int anio)
        {

            try
            {
                BorrarLiquidacionesDelMesYAnio(mes, anio);
                using (Context db = new Context())
                {

                    IEnumerable<Doctor> listaDoctores = db.Doctores.ToList();
                    IEnumerable<InformesDeConsulta> listaInformesCons = db.InformesDeConsultas.ToList();

                    foreach (Doctor doc in listaDoctores)
                    {
                        int cantidadDeConsultas = 0;
                        int plataGeneradaPorConsultas = 0;
                        if (doc.Activo)
                        {
                            LiquidacionDeSueldo nuevaLiquidacion = new LiquidacionDeSueldo();
                            foreach (InformesDeConsulta infCons in listaInformesCons)
                            {
                                if (infCons.Fecha.Month == mes && infCons.Fecha.Year == anio)
                                {
                                    if (doc.DoctorID == infCons.Doctor.DoctorID)
                                    {
                                        cantidadDeConsultas = cantidadDeConsultas + 1;
                                    }
                                }
                            }
                            plataGeneradaPorConsultas = (int)doc.ValorConsulta * cantidadDeConsultas;
                            nuevaLiquidacion.Doctor = doc;
                            nuevaLiquidacion.Anio = anio;
                            nuevaLiquidacion.Mes = mes;
                            nuevaLiquidacion.FechaRealizacion = DateTime.Now;
                            if (plataGeneradaPorConsultas > doc.SueldoMinimo)
                            {
                                nuevaLiquidacion.Importe = plataGeneradaPorConsultas;
                            }
                            else
                            {
                                nuevaLiquidacion.Importe = (int)doc.SueldoMinimo;
                            }
                            db.LiquidacionesDeSueldos.Add(nuevaLiquidacion);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            GC.Collect();
        }

        private void BorrarLiquidacionesDelMesYAnio(int mes, int anio)
        {
            IEnumerable<LiquidacionDeSueldo> result = new List<LiquidacionDeSueldo>();
            try
            {
                using (Context db = new Context())
                {
                    result = db.LiquidacionesDeSueldos.Where(ls => ls.Anio == anio && ls.Mes == mes).ToList();
                    foreach (var item in result)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                        db.LiquidacionesDeSueldos.Remove(item);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private LiquidacionDeSueldo GetLiquidacionID(int id)
        {
            LiquidacionDeSueldo result = null;
            try
            {

                using (Context db = new Context())
                {
                    result = db.LiquidacionesDeSueldos.SingleOrDefault(ls => ls.LiquidacionID == id);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}

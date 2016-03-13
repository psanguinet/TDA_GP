using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class ResultadosAnalisisLogic : IResultadosAnalisisLogic
    {
        public IEnumerable<Modelo.Models.ResultadoAnalisis> ListadoResultadoAnalisis(Modelo.Models.Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modelo.Models.ResultadoAnalisis> ListadoResultadoAnalisis(Modelo.Models.Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Modelo.Models.ResultadoAnalisis GetResultadoAnalisis(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Modelo.Models.ResultadoAnalisis resultadoAnalisis)
        {
            try
            {
                using (Context db = new Context())
                {
                    db.ResultadosAnalisis.Add(resultadoAnalisis);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Modelo.Models.ResultadoAnalisis resultadoAnalisis)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}

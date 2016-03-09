using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Models;

namespace BusinessLogic.Logic
{
    public interface IInformeDeConsultaLogic : IDisposable
    {
        InformesDeConsulta GetInformeDeConsulta(int id);
        void Save(InformesDeConsulta informeDeConsulta);
    }
}

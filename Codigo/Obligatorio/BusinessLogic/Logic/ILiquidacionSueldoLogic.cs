using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public interface ILiquidacionSueldoLogic : IDisposable
    {

        IEnumerable<LiquidacionDeSueldo> GetLiquidacionesDelMesYAnio(int mes, int anio);
        void HacerLiquidacionesDelMesYAnio(int mes, int anio);

    }
}

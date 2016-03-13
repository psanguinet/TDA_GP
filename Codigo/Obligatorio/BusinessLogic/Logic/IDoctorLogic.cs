using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public interface IDoctorLogic : IDisposable
    {
        IEnumerable<Doctor> ListDoctores();
        Doctor GetDoctor(int id);
        void Save(Doctor doctor);
        void Delete(int id);
        void Edit(Doctor doctor);
        bool UserExist(User user);
    }
}

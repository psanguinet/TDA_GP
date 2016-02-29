using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Models;

namespace BusinessLogic.Logic
{
    public class PersonaLogic : IPersonaLogic
    {
      
        /// <summary>
        /// Listado de personas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Persona> ListPersonas()
        {
            IEnumerable<Persona> result = new List<Persona>();
            try
            {
                using(Context db = new Context())
                {
                    result = db.Personas.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// Retorna una persona con PersonaID = id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Persona GetPersona(int id)
        {
            Persona persona = null;
            try
            {
                using (Context db = new Context())
                {
                    persona = db.Personas.SingleOrDefault(p => p.PersonaID == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return persona;
        }

        /// <summary>
        /// Guarda un persona
        /// </summary>
        /// <param name="persona"></param>
        public void Save(Persona persona)
        {
            try
            {
                using (Context db = new Context())
                { 
                
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }



        public void Delete(Persona persona)
        {
            using (Context db = new Context())
            {

            }
        }

        public void Edit(Persona persona)
        {
            using (Context db = new Context())
            {

            }
        }
    }
}

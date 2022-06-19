using DataAccess.Contexto;
using Dominio;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EF
{
    public class RepositorioPlanta : IRepositorioPlanta
    {
        ViveroContexto _dbContext;

        public RepositorioPlanta(ViveroContexto dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(Planta obj)
        {
            bool result = false;

            _dbContext.Add<Planta>(obj);
            result = _dbContext.SaveChanges() > 0;

            return result;
        }

        public IEnumerable<Planta> FindAll()
        {
           IEnumerable<Planta> result = null;

                result = _dbContext.Planta.ToList();

                return result;
          
        }

        public Planta FindById(object Clave)
        {
            Planta result = null;
            int id = (int)Clave;
            result = _dbContext.Planta.Find(id);

            return result;
        }

        public bool Remove(object Clave)
        {
            bool result = false;

            Planta autor = FindById(((Planta)Clave).IdPlanta);
            if (autor != null)
            {
                _dbContext.Planta.Remove(autor);
                result = _dbContext.SaveChanges() > 0;
            }
            return result;
        }

        public bool Update(Planta obj)
        {
            bool result = false;
            _dbContext.Update<Planta>(obj);
            result = _dbContext.SaveChanges() > 0;

            return result;
        }

    }
}

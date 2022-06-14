using DataAccess.Contexto;
using Dominio;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataAccess.EF
{
    public class RepositorioPlaza : IRepositorioPlaza
    {
        Vivero _dbContext;

        public RepositorioPlaza(Vivero dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(Plaza obj)
        {
            bool result = false;

            _dbContext.Add<Plaza>(obj);
            result = _dbContext.SaveChanges() > 0;

            return result;
        }

        public IEnumerable<Plaza> FindAll()
        {
            IEnumerable<Plaza> result = null;

            result = _dbContext.Plaza.ToList();

            return result;
        }

        public Plaza FindById(object Clave)
        {
            Plaza result = null;
            int id = (int)Clave;
            result = _dbContext.Plaza.Find(id);

            return result;
        }

        public bool Remove(object Clave)
        {
            bool result = false;
            Plaza autor = FindById(Clave);
            _dbContext.Plaza.Remove(autor);
            result = _dbContext.SaveChanges() > 0;

            return result;
        }

        public bool Update(Plaza obj)
        {
            bool result = false;
            _dbContext.Update<Plaza>(obj);
            result = _dbContext.SaveChanges() > 0;

            return result;
        }
    }
}

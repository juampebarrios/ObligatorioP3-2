using DataAccess.Contexto;
using Dominio;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataAccess.EF
{
    public class RepositorioImportacion : IRepositorioImportacion
    {
        public readonly ViveroContexto _dbContext;

        public RepositorioImportacion(ViveroContexto dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(Importacion obj)
        {
            bool result = false;
            if (obj != null)
            {
                _dbContext.Add<Importacion>(obj);
                result = _dbContext.SaveChanges() > 0;
            }
            return result;
        }

        public IEnumerable<Importacion> FindAll()
        {
            IEnumerable<Importacion> result = null;
            
            result = _dbContext.Importacion.ToList();

            return result;
        }

        public Importacion FindById(object Clave)
        {
            Importacion result = null;
            int id = (int)Clave;
            if (Clave != null)
                result = _dbContext.Importacion.Find(id);

            return result;
        }

        public bool Remove(object Clave)
        {
            bool result = false;
            if (Clave != null)
            {
                Importacion autor = FindById(((Importacion)Clave).IdCompra);
                if (autor != null)
                {
                    _dbContext.Importacion.Remove(autor);
                    result = _dbContext.SaveChanges() > 0;
                }
            }
            return result;
        }

        public bool Update(Importacion obj)
        {
            bool result = false;
            if (obj != null)
            {
                _dbContext.Update<Importacion>(obj);
                result = _dbContext.SaveChanges() > 0;
            }
            return result;
        }
    }
}

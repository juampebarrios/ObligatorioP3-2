using DataAccess.Contexto;
using Dominio;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EF
{
    public class RepositorioTipoPlanta : IRepositorioTipoPlanta
    {
        public readonly ViveroContexto _dbContext;

        public RepositorioTipoPlanta(ViveroContexto dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(TipoPlanta obj)
        {
            bool result = false;
            if (obj != null)
            {
                _dbContext.Add<TipoPlanta>(obj);
                result = _dbContext.SaveChanges() > 0;
            }
            return result;
        }

        public IEnumerable<TipoPlanta> FindAll()
        {
            IEnumerable<TipoPlanta> result = null;

            result = _dbContext.TipoPlanta.ToList();

            return result;
        }

        public TipoPlanta FindById(object Clave)
        {
            
            TipoPlanta result = null;
            if (Clave != null)
            {
                int id = (int)Clave;
                result = _dbContext.TipoPlanta.Find(id);
            }
            return result;
        }

        public bool Remove(object Clave)
        {
            bool result = false;
            if (Clave != null)
            {
                TipoPlanta tp = FindById(((TipoPlanta)Clave).IdTipoPlanta);

                var t = from miPlanta in _dbContext.Planta where miPlanta.IdTipoPlanta == tp.IdTipoPlanta select miPlanta.IdTipoPlanta;
                _dbContext.TipoPlanta.Remove(tp);
                result = _dbContext.SaveChanges() > 0;

            }
            return result;
        }

        public bool Update(TipoPlanta obj)
        {
            bool result = false;
            if (obj != null)
            {
                _dbContext.Update<TipoPlanta>(obj);
                result = _dbContext.SaveChanges() > 0;
            }
            return result;
        }
    }
}

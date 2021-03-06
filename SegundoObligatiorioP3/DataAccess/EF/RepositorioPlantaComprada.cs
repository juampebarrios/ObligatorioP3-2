using DataAccess.Contexto;
using Dominio;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EF
{
    public class RepositorioPlantaComprada : IRepositorioPlantaComprada
    {
        public readonly ViveroContexto _dbContext;

        public RepositorioPlantaComprada(ViveroContexto dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(PlantaComprada obj)
        {
            bool result = false;
            if (obj != null)
            {
                _dbContext.Add<PlantaComprada>(obj);
                // var res = _dbContext.Planta.Where(p => p.IdPlanta == obj.IdPlanta);
                // _dbContext.Entry(res).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                result = _dbContext.SaveChanges() > 0;
            }
            return result;
        }

        public bool Add(PlantaComprada obj, Planta p, int cantidad, double precio)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlantaComprada> FindAll()
        {
            IEnumerable<PlantaComprada> result = null;

            result = _dbContext.PlantaComprada.ToList();

            return result;
        }

        public PlantaComprada FindById(object Clave)
        {
            PlantaComprada result = null;
            if (Clave != null)
            {
                int id = (int)Clave;
                result = _dbContext.PlantaComprada.Find(id);
            }
            return result;
        }

        public bool Remove(object Clave)
        {
            bool result = false;
            if (Clave != null)
            {
                PlantaComprada pc = FindById(((PlantaComprada)Clave).IdPlantaComprada);
                if (pc != null)
                {
                    _dbContext.PlantaComprada.Remove(pc);
                    result = _dbContext.SaveChanges() > 0;
                }
            }
            return result;
        }

        public bool Update(PlantaComprada obj)
        {
            bool result = false;
            if (obj != null)
            {
                _dbContext.Update<PlantaComprada>(obj);
                result = _dbContext.SaveChanges() > 0;
            }
            return result;
        }
    }
}

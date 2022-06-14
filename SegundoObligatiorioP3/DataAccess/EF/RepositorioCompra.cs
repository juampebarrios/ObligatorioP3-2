using DataAccess.Contexto;
using Dominio;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataAccess.EF
{
    public class RepositorioCompra : IRepositoCompra
    {
        Vivero _dbContext;
        public RepositorioCompra(Vivero dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Compra obj)
        {

            bool result = false;

            _dbContext.Add<Compra>(obj);
            result = _dbContext.SaveChanges() > 0;

            return result;
        }

        public IEnumerable<Compra> FindAll()
        {
            IEnumerable<Compra> result = null;

            result = _dbContext.Compra.ToList();

            return result;
        }

        public Compra FindById(object Clave)
        {
            Compra result = null;
            int id = (int)Clave;
            result = _dbContext.Compra.Find(id);

            return result;
        }

        public bool Remove(object Clave)
        {
            bool result = false;
            Compra miCompra = FindById(Clave);
            _dbContext.Compra.Remove(miCompra);
            result = _dbContext.SaveChanges() > 0;

            return result;
        }

        public bool Update(Compra obj)
        {
            bool result = false;
            _dbContext.Update<Compra>(obj);
            result = _dbContext.SaveChanges() > 0;

            return result;
        }
    }
}

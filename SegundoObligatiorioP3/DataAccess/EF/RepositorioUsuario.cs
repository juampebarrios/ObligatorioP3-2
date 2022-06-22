using DataAccess.Contexto;
using Dominio;
using Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public readonly ViveroContexto _dbContext;
        public RepositorioUsuario(ViveroContexto dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(Usuario obj)
        {
            bool result = false;
            if (obj != null)
            {
                _dbContext.Add<Usuario>(obj);
                result = _dbContext.SaveChanges() > 0;
            }
            return result;
        }

        public IEnumerable<Usuario> FindAll()
        {
            IEnumerable<Usuario> result = null;

            result = _dbContext.Usuario.ToList();

            return result;
        }

        public Usuario FindById(object Clave)
        {
            Usuario result = null;
            if (Clave == null)
                return result;
            int id = (int)Clave;
            result = _dbContext.Usuario.Find(id);

            return result;
        }

        public Usuario Login(string usu, string pass)
        {
            var result = from miUsuario in _dbContext.Usuario where miUsuario.Email == usu && miUsuario.Password == pass select miUsuario.IdUsuario;
            Usuario logueo = FindById(result.FirstOrDefault());
            
            return logueo;
            
        }

        public bool Remove(object Clave)
        {
            bool result = false;
            if (Clave != null)
            {
                Usuario u = FindById(((Usuario)Clave).IdUsuario);
                _dbContext.Usuario.Remove(u);
                result = _dbContext.SaveChanges() > 0;
            }
            return result;
        }

        public bool Update(Usuario obj)
        {
            bool result = false;
            if (obj != null)
            {
                _dbContext.Update<Usuario>(obj);
                result = _dbContext.SaveChanges() > 0;
            }
            return result;
        }
    }
}

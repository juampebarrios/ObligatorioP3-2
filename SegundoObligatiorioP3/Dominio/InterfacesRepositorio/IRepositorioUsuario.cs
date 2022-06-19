using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioUsuario : IRepositorios<Usuario>
    {
        public Usuario Login(string usu, string pass);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioTipoPlanta : IRepositorios<TipoPlanta>
    {

        public IEnumerable<TipoPlanta> Buscar(string name);
    }
}

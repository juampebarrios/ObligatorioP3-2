using System;
using System.Collections.Generic;
using System.Text;
using Dominio;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioPlanta : IRepositorios<Planta>
    {
        public Planta FindByName(object Name);

        public IEnumerable<Planta> Buscar(string name, int id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Dominio;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioPlanta : IRepositorios<Planta>
    {
        public Planta FindByName(object Name);
    }
}

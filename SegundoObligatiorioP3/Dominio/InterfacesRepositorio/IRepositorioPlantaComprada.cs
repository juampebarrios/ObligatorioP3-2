using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioPlantaComprada : IRepositorios<PlantaComprada>
    {
        public bool Add(PlantaComprada obj, Planta p, int cantidad, double precio);
    }
}

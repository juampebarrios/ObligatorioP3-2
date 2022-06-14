using System;
using System.Collections.Generic;
using System.Text;
using Dominio;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorios<T> where T : class
	{
		public bool Add(T obj);
		public bool Remove(object Clave);
		public bool Update(T obj);
		public T FindById(object Clave);
		public IEnumerable<T> FindAll();
	}
}

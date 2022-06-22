using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using DataAccess;
using Dominio.InterfacesRepositorio;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiVivero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlazaController : ControllerBase
    {

        private readonly IRepositorioPlaza _repoPlaza;
        private readonly IRepositoCompra _repoCompra;

        public PlazaController(IRepositoCompra repoCompra, IRepositorioPlaza repoPlaza)
        {
            _repoPlaza = repoPlaza;
            _repoCompra = repoCompra;
        }

        // GET: api/<CompraController>[HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Plaza))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            return Ok(_repoPlaza.FindAll());
        }

        // GET api/<CompraController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Plaza autor = _repoPlaza.FindById(id);
            if (autor != null)
            {
                return Ok(autor);
            }
            else
                return NotFound();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            Plaza plaza = _repoPlaza.FindById(id);
            bool result = _repoPlaza.Remove(plaza);
            if (result)
            {
                return NoContent();
            }
            else
                return NotFound();

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Add(Plaza miPlaza)
        {
            if (miPlaza != null)
            {
                if (_repoPlaza.Add(miPlaza))
                {
                    string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                    Uri uri = new Uri(Request.Scheme + "://" + Request.Host + "/api/" + controllerName + "/" + miPlaza.IdCompra);

                    return Created(uri.AbsoluteUri, miPlaza);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(Plaza miPlaza)
        {
            if (ModelState.IsValid)
            {
                _repoPlaza.Update(miPlaza);
                return Ok(miPlaza);

            }
            else
            {
                return BadRequest();
            }
        }
    }

}
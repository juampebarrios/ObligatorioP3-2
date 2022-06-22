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
    public class CompraController : ControllerBase
    {

        private readonly IRepositoCompra _repoCompra;

        public CompraController(IRepositoCompra repoCompra)
        {
            _repoCompra = repoCompra;
        }

        // GET: api/<CompraController>[HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Compra))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            return Ok(_repoCompra.FindAll());
        }

        // GET api/<CompraController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Compra autor = _repoCompra.FindById(id);
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
            Compra autor = _repoCompra.FindById(id);
            bool result = _repoCompra.Remove(autor);
            if (result)
            {
                return NoContent();
            }
            else
                return NotFound();

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Add(Compra miCompra)
        {
            if (miCompra != null)
            {
                if (_repoCompra.Add(miCompra))
                {
                    string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                    Uri uri = new Uri(Request.Scheme + "://" + Request.Host + "/api/" + controllerName + "/" + miCompra.IdCompra);

                    return Created(uri.AbsoluteUri, miCompra);
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
        public IActionResult Update(Compra miCompra)
        {
            if (ModelState.IsValid)
            {
                _repoCompra.Update(miCompra);
                return Ok(miCompra);

            }
            else
            {
                return BadRequest();
            }
        }
    }
}

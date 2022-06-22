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
    public class ImportacionController : ControllerBase
    {

        private readonly IRepositorioImportacion _repoImpo;
        private readonly IRepositoCompra _repoCompra;

        public ImportacionController(IRepositoCompra repoCompra, IRepositorioImportacion repoImpo)
        {
            _repoImpo = repoImpo;
            _repoCompra = repoCompra;
        }

        // GET: api/<CompraController>[HttpGet]
       // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Importacion))]
       // [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            return Ok(_repoImpo.FindAll());
        }

        // GET api/<CompraController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Importacion autor = _repoImpo.FindById(id);
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
            Importacion impo = _repoImpo.FindById(id);
            bool result = _repoImpo.Remove(impo);
            if (result)
            {
                return NoContent();
            }
            else
                return NotFound();

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(Importacion miImportacion)
        {
            if (miImportacion != null)
            {
                if (_repoImpo.Add(miImportacion))
                {
                    string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                    Uri uri = new Uri(Request.Scheme + "://" + Request.Host + "/api/" + controllerName + "/" + miImportacion.IdCompra);

                    return Created(uri.AbsoluteUri, miImportacion);
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
        public IActionResult Update(Importacion miImpo)
        {
            if (ModelState.IsValid)
            {
                _repoImpo.Update(miImpo);
                return Ok(miImpo);

            }
            else
            {
                return BadRequest();
            }
        }
    }
}

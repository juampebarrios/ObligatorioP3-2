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

namespace VivieroebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportacionController : ControllerBase
    {
        private readonly IRepositorioImportacion _repoImpo;

        public ImportacionController( IRepositorioImportacion repoImpo)
        {
            _repoImpo = repoImpo;
        }
        // GET: api/<ImportacionController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repoImpo.FindAll());
        }

        // GET api/<ImportacionController>/5
        [HttpGet("{idCompra}")]
        public IActionResult Get(int idCompra)
        {
            return Ok(_repoImpo.FindById(idCompra));
        }

        // POST api/<ImportacionController>
        [HttpPost]
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

        // PUT api/<ImportacionController>/5
        [HttpPut]
        
        public ActionResult Put(Importacion miImp)
        {
            if (ModelState.IsValid)
            {
                _repoImpo.Update(miImp);
                return Ok(miImp);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ImportacionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Importacion miImp = _repoImpo.FindById(id);
            bool result = _repoImpo.Remove(miImp);
            if (result)
            {
                return NoContent();
            }
            else
                return NotFound();
        }
    }
}

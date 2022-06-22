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
    public class PlazaController : ControllerBase
    {
        private readonly IRepositorioPlaza _reposPlaza;
        private readonly IRepositorioPlanta _reposPlanta;
        public PlazaController(IRepositorioPlaza reposPlaza)
        {
               _reposPlaza = reposPlaza;
        }
        // GET: api/<ImportacionController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_reposPlaza.FindAll());
        }

        // GET api/<ImportacionController>/5
        [HttpGet("{idCompra}")]
        public IActionResult Get(int idCompra)
        {
            return Ok(_reposPlaza.FindById(idCompra));
        }

        // POST api/<ImportacionController>
        [HttpPost]
        public IActionResult Post(Plaza miPlaza)
        {
            if (miPlaza != null)
            {

                if (_reposPlaza.Add(miPlaza))
                {
                    foreach (var item in miPlaza.PlantasCompradas) 
                    {
                        item.IdCompra = miPlaza.IdCompra;
                    }
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

        // PUT api/<ImportacionController>/5
        [HttpPut]

        public ActionResult Put(Plaza miPlaza)
        {
            if (ModelState.IsValid)
            {
                _reposPlaza.Update(miPlaza);
                return Ok(miPlaza);
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
            Plaza miPlaza = _reposPlaza.FindById(id);
            bool result = _reposPlaza.Remove(miPlaza);
            if (result)
            {
                return NoContent();
            }
            else
                return NotFound();
        }
    }
}

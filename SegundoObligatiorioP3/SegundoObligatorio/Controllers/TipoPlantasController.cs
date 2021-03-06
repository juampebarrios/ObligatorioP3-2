using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexto;
using Dominio;
using Dominio.InterfacesRepositorio;
using SegundoObligatorio.Models;
using Microsoft.AspNetCore.Http;

namespace SegundoObligatorio.Controllers
{
    public class TipoPlantasController : Controller
    {
        private readonly IRepositorioTipoPlanta _repoTipoPlanta;

        public TipoPlantasController(IRepositorioTipoPlanta repoTipoPlanta)
        {
            _repoTipoPlanta = repoTipoPlanta;
        }

        

        // GET: Plantas
        public IActionResult Index()
        {
            var temp = TempData["usuario"];


            string nombre = HttpContext.Session.GetString("usuario");
            if (nombre != null)
            {

                ViewBag.Mensaje = "No se encontraron Tipos";

                IEnumerable<TipoPlanta> misTipoPlanta = _repoTipoPlanta.FindAll();
                if (misTipoPlanta != null)
                    return View(misTipoPlanta);
                else

                    return View(ViewBag.Mensaje);
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Plantas/Details/5
        public IActionResult Details(int? id)
        {
            string nombre = HttpContext.Session.GetString("usuario");
            if (nombre != null)
            {
                if (id == null)
            {
                return NotFound();
            }

            var tipo = _repoTipoPlanta.FindById(id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Plantas/Create
        public IActionResult Create()
        {
            string nombre = HttpContext.Session.GetString("usuario");
            if (nombre != null)
            {
                return View();
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: Plantas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoPlanta miTipoPlantas)
        {
            try
            {
                string nombre = HttpContext.Session.GetString("usuario");
                if (nombre != null)
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(miTipoPlantas.NombreUnico,
                                               "^[a-zA-Z'.]"))
                {
                    ViewBag.Retorno = "Error - Nombre no puede contener numeros";
                    return View();
                }
                if (ModelState.IsValid)
                {

                    _repoTipoPlanta.Add(miTipoPlantas);
                    return RedirectToAction(nameof(Index));
                }
                return View(miTipoPlantas);
                }
                return View("~/Views/Home/Index.cshtml");
            }
            catch (Exception)
            {

                return View("Error", new ErrorViewModel() { RequestId = miTipoPlantas.IdTipoPlanta.ToString() });
            }
        }

        // GET: Plantas/Edit/5
        public IActionResult Edit(int? id)
        {
            string nombre = HttpContext.Session.GetString("usuario");
            if (nombre != null)
            {
                if (id == null)
            {
                return NotFound();
            }

            var tipo = _repoTipoPlanta.FindById(id);
            if (tipo == null)
            {
                return NotFound();
            }
            return View(tipo);
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: Plantas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TipoPlanta mitipo)
        {
            try
            {
                string nombre = HttpContext.Session.GetString("usuario");
                if (nombre != null)
                {
                    if (ModelState.IsValid)
                {
                    _repoTipoPlanta.Update(mitipo);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(mitipo);

                    }
                }
                return View("~/Views/Home/Index.cshtml");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel() { RequestId = mitipo.IdTipoPlanta.ToString() });
            }
        }

        // GET: Plantas/Delete/5
        public IActionResult Delete(int? id)
        {
            string nombre = HttpContext.Session.GetString("usuario");
            if (nombre != null)
            {
                if (id == null)
            {
                return NotFound();
            }

            var tipo = _repoTipoPlanta.FindById(id);
            if (tipo == null)
            {
                return NotFound();
            }
            
            return View(tipo);
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: Plantas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            
            try
            {
                string nombre = HttpContext.Session.GetString("usuario");
                if (nombre != null)
                {
                int miId = Convert.ToInt32(ViewBag.id);
                var tipo = _repoTipoPlanta.FindById(id);
                if (tipo != null)
                {
                    _repoTipoPlanta.Remove(tipo);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
                }
                return View("~/Views/Home/Index.cshtml");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel() { RequestId = id.ToString() });
            }


        }

        [HttpPost]
        public ActionResult BuscarTipo(string texto)
        {
            string nombre = HttpContext.Session.GetString("usuario");
            if (nombre != null)
            {
                ViewBag.Mensaje = "No se encontraron Tipos";

                IEnumerable<TipoPlanta> misTipoPlanta = _repoTipoPlanta.Buscar(texto);
                if (misTipoPlanta != null)
                    return View(misTipoPlanta);
                else

                    return View(ViewBag.Mensaje);
            }
            else
            {

                return View("~/Views/Home/Index.cshtml");


            }

        }

    }
}

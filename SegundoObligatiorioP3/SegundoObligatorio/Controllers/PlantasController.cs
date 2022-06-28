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
    public class PlantasController : Controller
    {
        private readonly IRepositorioPlanta _repoPlanta;
        private readonly IRepositorioTipoPlanta _repoTipo;



        public PlantasController(IRepositorioPlanta repoPlanta, IRepositorioTipoPlanta repoTipo)
        {
            _repoPlanta = repoPlanta;
            _repoTipo = repoTipo;
        }

        // GET: Plantas
        public IActionResult Index()
        {
            string nombre = HttpContext.Session.GetString("usuario");
            if (nombre != null)
            {
                ViewBag.Mensaje = "No se encontraron Plantas";
            


            IEnumerable<Planta> misPlantas = _repoPlanta.FindAll();
            if (misPlantas != null)
                return View(misPlantas);
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

            var planta = _repoPlanta.FindById(id);
            if (planta == null)
            {
                return NotFound();
            }

            return View(planta);
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: Plantas/Create
        public IActionResult Create()
        {
            string nombre = HttpContext.Session.GetString("usuario");
            if (nombre != null)
            {
                ViewBag.Tipos = _repoTipo.FindAll();
            if (ViewBag.Retorno != null)
            { 
                     ViewBag.Tipos = _repoTipo.FindAll(); 
                return View(ViewBag.Retorno);}
            return View();
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: Plantas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Planta planta)
        {
            try
            {
                string nombre = HttpContext.Session.GetString("usuario");
                if (nombre != null)
                {
                    if (ModelState.IsValid) 
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(planta.NombreCientifico,
                                           "^[a-zA-Z'.]$")) 
                    {
                        ViewBag.Retorno = "Error - Nombre no puede contener numeros";
                        ViewBag.Tipos = _repoTipo.FindAll();
                    }
                    if (_repoPlanta.FindByName(planta.NombreCientifico) != null) 
                    {
                        ViewBag.Retorno = "Erro1r - Ya existe planta con ese Nombre Cientifico";
                        ViewBag.Tipos = _repoTipo.FindAll();
                    }
                    return View();
                }
                _repoPlanta.Add(planta);
                return RedirectToAction(nameof(Index));
                }
                return View("~/Views/Home/Index.cshtml");

            }
            catch (Exception)
            {

                return View("Error", new ErrorViewModel() { RequestId = planta.IdPlanta.ToString() });
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

            var planta = _repoPlanta.FindById(id);
            if (planta == null)
            {
                return NotFound();
            }
            ViewBag.Tipos = _repoTipo.FindAll();
            return View(planta);
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: Plantas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Planta planta)
        {
            try
            {
                string nombre = HttpContext.Session.GetString("usuario");
                if (nombre != null)
                {
                    if (ModelState.IsValid)
                {
                    _repoPlanta.Update(planta);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(planta);

                    }
                }
                return View("~/Views/Home/Index.cshtml");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel() { RequestId = planta.IdPlanta.ToString() });
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

            var planta = _repoPlanta.FindById(id);
            if (planta == null)
            {
                return NotFound();
            }

            return View(planta);
            }
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public ActionResult BuscarPlanta(int id, string texto)
        {
            string nombre = HttpContext.Session.GetString("usuario");
            if (nombre != null)
            {
                return View(_repoPlanta.Buscar(texto,id));
            }
            else
            {

                return View("~/Views/Home/Index.cshtml");


            }

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
                    var planta = _repoPlanta.FindById(id);
                if (planta != null)
                {
                    _repoPlanta.Remove(planta);
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

        
    }
}

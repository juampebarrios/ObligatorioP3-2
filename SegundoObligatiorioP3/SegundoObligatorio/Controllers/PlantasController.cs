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
            ViewBag.Mensaje = "No se encontraron Plantas";
            if (ViewData["retorno"] == null)
            {
                ViewData["retorno"] = "";
            }
           
            IEnumerable<Planta> misPlantas = _repoPlanta.FindAll();
            if (misPlantas != null)
                return View(misPlantas);
            else
               
            return View(ViewBag.Mensaje);
        }

        // GET: Plantas/Details/5
        public IActionResult Details(int? id)
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

        // GET: Plantas/Create
        public IActionResult Create()
        {
            ViewBag.Tipos = _repoTipo.FindAll();
            ViewData["retorno"] = "";
            return View();
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
                if (ModelState.IsValid)
                {
                    if (_repoPlanta.FindByName(planta.NombreCientifico) != null)
                    {
                        ViewData["retorno"] = "Nombre cientifico existente, no se puede agregar la planta";
                        
                    }
                    else
                    {
                        _repoPlanta.Add(planta);
                    }
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View("Error", new ErrorViewModel() { RequestId = planta.IdPlanta.ToString() });
            }
        }

        // GET: Plantas/Edit/5
        public IActionResult Edit(int? id)
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

        // POST: Plantas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Planta planta)
        {
            try
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
            catch (Exception)
            {
                return View("Error", new ErrorViewModel() { RequestId = planta.IdPlanta.ToString() });
            }
        }

        // GET: Plantas/Delete/5
        public IActionResult Delete(int? id)
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

        // POST: Plantas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
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
            catch (Exception)
            {
                return View("Error", new ErrorViewModel() { RequestId = id.ToString() });
            }


        }

        
    }
}

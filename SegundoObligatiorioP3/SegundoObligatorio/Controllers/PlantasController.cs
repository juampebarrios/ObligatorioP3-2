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


        public PlantasController(IRepositorioPlanta repoPlanta)
        {
            _repoPlanta = repoPlanta;
        }

        // GET: Plantas
        public IActionResult Index()
        {
            return View(_repoPlanta.FindAll());
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
            return View();
        }

        // POST: Plantas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Planta planta)
        {
            try {
                if (ModelState.IsValid)
                {
                    _repoPlanta.Add(planta);
                    return RedirectToAction(nameof(Index));
                }
                return View(planta);
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

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

            ViewBag.Mensaje = "No se encontraron Tipos";

            IEnumerable<TipoPlanta> misTipoPlanta = _repoTipoPlanta.FindAll();
            if (misTipoPlanta != null)
                return View(misTipoPlanta);
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

            var tipo = _repoTipoPlanta.FindById(id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
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
        public IActionResult Create(TipoPlanta miTipoPlantas)
        {
            try
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
            catch (Exception)
            {

                return View("Error", new ErrorViewModel() { RequestId = miTipoPlantas.IdTipoPlanta.ToString() });
            }
        }

        // GET: Plantas/Edit/5
        public IActionResult Edit(int? id)
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

        // POST: Plantas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TipoPlanta mitipo)
        {
            try
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
            catch (Exception)
            {
                return View("Error", new ErrorViewModel() { RequestId = mitipo.IdTipoPlanta.ToString() });
            }
        }

        // GET: Plantas/Delete/5
        public IActionResult Delete(int? id)
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

        // POST: Plantas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            int miId = Convert.ToInt32(ViewBag.id);
            try
            {
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
            catch (Exception)
            {
                return View("Error", new ErrorViewModel() { RequestId = id.ToString() });
            }


        }

    }
}

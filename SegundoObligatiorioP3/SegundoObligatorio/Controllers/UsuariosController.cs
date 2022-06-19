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
    public class UsuariosController : Controller
    {
        private readonly IRepositorioUsuario _repoUsu;

        public UsuariosController(IRepositorioUsuario repoUsu)
        {
            _repoUsu = repoUsu;
        }


        // GET: Usuarios
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();

        }
        public IActionResult Login()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Login(string usu, string pass)
        {
            if (usu != "" && pass != "")
            {
                Usuario miUsu = _repoUsu.Login(usu, pass);
                if (miUsu != null)
                {
                    ViewBag.usuario = miUsu;
                    return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("~/Views/Login/Index.cshtml");
        }



        //----------------------------------------------------------//

        // GET: Usuarios/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _repoUsu.FindById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario miUsu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repoUsu.Add(miUsu);
                    return RedirectToAction(nameof(Index));
                }
                return View(miUsu);
            }
            catch (Exception)
            {

                return View("Error", new ErrorViewModel() { RequestId = miUsu.IdUsuario.ToString() });
            }
        }

        // GET: Usuarios/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _repoUsu.FindById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario miUsu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repoUsu.Update(miUsu);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(miUsu);

                }
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel() { RequestId = miUsu.IdUsuario.ToString() });
            }
        }

        // GET: Usuarios/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo = _repoUsu.FindById(id);
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
                var tipo = _repoUsu.FindById(id);
                if (tipo != null)
                {
                    _repoUsu.Remove(tipo);
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

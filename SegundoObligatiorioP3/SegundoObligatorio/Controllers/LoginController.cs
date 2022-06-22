using Dominio;
using Dominio.InterfacesRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoObligatorio.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRepositorioUsuario _repoUsu;

        public LoginController(IRepositorioUsuario repoUsu)
        {
            _repoUsu = repoUsu;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            //  return View("~/Views/Home/Index.cshtml");
            return View();
        }
        [HttpPost]
        public ActionResult Login(string usu, string pass)
        {
            if (usu != "" && pass != "")
            {
                Usuario miUsu = _repoUsu.Login(usu, pass);
                if (miUsu != null)
                {
                    HttpContext.Session.SetString("usuario", usu);
                    ViewBag.usuario = miUsu;
                    ViewData["usuario"] = miUsu;
                    return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            ViewData["usuario"] = null;
            ViewBag.usuario = null;
            return View("~/Views/Home/Index.cshtml");
        }
        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction("~/Views/Home/Index.cshtml");
            }
            catch
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return View("~/Views/Home/Index.cshtml");
            }
            catch
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

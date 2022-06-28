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

                string nombre = HttpContext.Session.GetString("usuario");
                if (nombre != null)
                {
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
        [HttpPost]
        public IActionResult AgregarPred()
        {
            _repoUsu.AddUsers();
            return View("~/Login");
        }
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
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

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_Practice.IService;
using WebApplication_Practice.Models;

namespace WebApplication_Practice.Controllers
{
    public class LoginController : Controller
    {
        private ILogin _login;
        public LoginController(ILogin login)
        {
            _login = login;
        }
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            var loginlist = _login.List();
            return View(loginlist);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LoginModel mdl)
        {
            string result = _login.Save(mdl);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _login.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = _login.DetailsByid(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(LoginModel dpt)
        {
            _login.Edit(dpt);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DetailsByid(int id)
        {
            var result = _login.DetailsByid(id);
            return View(result);
        }
    }

}
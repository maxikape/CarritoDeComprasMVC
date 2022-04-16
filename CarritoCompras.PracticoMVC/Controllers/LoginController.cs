using Entidades.Entidades;
using Servicios;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;

namespace CarritoCompras.PracticoMVC.Controllers
{
    public class LoginController : Controller

    {


        private ServicioLogin _servicioLogin;
        public LoginController()
        {
            this._servicioLogin = new ServicioLogin();
        }


        public ActionResult Index()
        {

            return View();
        }




        //private bool Auxiliar (string NombreUsuario, string Password)
        //{
        //    var p = _servicioLogin.Login(NombreUsuario, Password);
        //    Session["NombreUsuario"] = NombreUsuario;

        //    if (Session["NombreUsuario"] != null && p != false)
        //    {

        //        return true;

        //    }

        //    else
        //    {
        //        return false;

        //    }


        //}

        [HttpPost]
        public ActionResult Logeo(string NombreUsuario, string Password)
        {

            var p = _servicioLogin.Login(NombreUsuario, Password);


            //user
            if (ModelState.IsValid == true && p != null && p.IdRol == 2)
            {
                Session["NombreUsuario"] = p.NombreUsuario;
                Session["Rol"] = p.IdRol;

                return RedirectToAction("Index", "Home");
            }

            //Admin
            else if (ModelState.IsValid == true && p != null && p.IdRol == 1)
            {
                Session["NombreUsuario"] = p.NombreUsuario;
                Session["Rol"] = p.IdRol;
                return RedirectToAction("Index", "Admin", p.IdRol);
            }

            //    //Response.AppendHeader("Cache-Control", "no-store");




            //Error
            else
            {
                return View("Index");
            }


        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }


        public ActionResult AccesoNegado()
        {

            var a = Session["Rol"].ToString();
            if (Session["Rol"].ToString() == "1")

            {
                ViewBag.item = a;
                return View();
            }
            return View();
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}

        }


    }
}
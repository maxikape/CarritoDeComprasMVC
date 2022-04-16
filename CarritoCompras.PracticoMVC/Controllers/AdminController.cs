
using Daos.Daos;
using Entidades.Entidades;
using Entidades.Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarritoCompras.PracticoMVC.Controllers
{
    public class AdminController : Controller
    {

        private ServicioProductos _servicioProductos;
        public AdminController()
        {
            this._servicioProductos = new ServicioProductos();
        }

        


        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                //si no esta logueado redirige al login

                if (Session["Rol"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                

                else if (Session["Rol"].ToString() == "1")
                {
                    //var s = Session["Nombre"].ToString();
                    var modelo = _servicioProductos.ListarProductosAdmin();
                    return View("Index", modelo);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return RedirectToAction("Index", "Login");


        }


        [HttpGet]
        public ActionResult Create()
        {
            //si no esta logueado redirige al login
            if (Session["Rol"] == null)
            {
                return RedirectToAction("AccesoNegado", "Login");
            }


            if (Session["Rol"].ToString() == "1")
            {

                var modeloRol = _servicioProductos.MostrarMarcas();

                List<SelectListItem> items = modeloRol.Marcas.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.NombreMarca,
                        Value = d.IdMarca.ToString(),
                        Selected = false


                    };
                });
                //mando la lista de items en el viewbag
                ViewBag.items = items;
                return View();
                
            }

            return RedirectToAction("Index", "Login");

        }


        [HttpPost]
        public ActionResult Create(Producto producto)
        {


            if (ModelState.IsValid == true)
            {
                //Ruta de subida
                string rutaSitio = Server.MapPath("/Images/Productos/");
                string _path = Path.Combine(rutaSitio + producto.img.FileName);
                //Ruta para guardar la URL
                string _pathRuta = Path.Combine("/Images/Productos/" + producto.img.FileName);
                //producto.img = "\\Images\\Productos\\" + producto.img;
                producto.img.SaveAs(_path);
                producto.UrlImage = _pathRuta;

                _servicioProductos.InsertarProducto(producto);

                return RedirectToAction("Index");

            }

            else
            {
                return RedirectToAction("Index");
            }



        }




        [HttpGet]
        public ActionResult Edit(int id)
        {
            //si no esta logueado redirige al login

            if (Session["Rol"] == null)
            {
                return RedirectToAction("Index", "Login");
            }


            else if (Session["Rol"].ToString() == "1")
            {

                var recupero = _servicioProductos.RecuperarPorId(id);
                   

                var modeloRol = _servicioProductos.MostrarMarcas();
                List<SelectListItem> items = modeloRol.Marcas.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.NombreMarca,
                        Value = d.IdMarca.ToString(),
                        Selected = false

                    };
                });
                //mando la lista de items en el viewbag
                ViewBag.items = items;
                return View(recupero);
            }
            return RedirectToAction("Index", "Login");

        }


        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            //Ruta de subida
            string rutaSitio = Server.MapPath("/Images/Productos/");
            string _path = Path.Combine(rutaSitio + producto.img.FileName);
            //Ruta para guardar la URL
            string _pathRuta = Path.Combine("/Images/Productos/" + producto.img.FileName);
            //producto.img = "\\Images\\Productos\\" + producto.img;
            producto.img.SaveAs(_path);
            producto.UrlImage = _pathRuta;

            _servicioProductos.ModificarProducto(producto);

            return RedirectToAction("Index");


        }

    }
}

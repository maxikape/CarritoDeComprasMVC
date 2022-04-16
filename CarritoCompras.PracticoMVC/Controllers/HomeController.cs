using Daos.Daos;
using Entidades.Entidades;
using Entidades.Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarritoCompras.PracticoMVC.Controllers
{
    public class HomeController : Controller
    {
        private ServicioProductos _servicioProductos;
        private ServicioUsuario _servicioUsuario;
        private ServicioCarrito _serviciocarrito;
        public HomeController()
        {
            this._servicioProductos = new ServicioProductos();
            this._servicioUsuario = new ServicioUsuario();
            this._serviciocarrito = new ServicioCarrito();
        }



        public ActionResult Index()
        {
            //redirige login

            //if (Session["Rol"].ToString() == "2")
            var pro = _servicioProductos.MostrarProductosUsuario();
              
            //var tuple = new Tuple<List<Producto>, CarritoModel>(pro, new CarritoModel()); 

        
            return View(pro);
            
            //else if (Session["Rol"] == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
             
            //return RedirectToAction("AccesoNegado", "Login",Session["Rol"]);

        }  


        
      

        //[HttpGet]
        //public JsonResult AgregarCarrito(CarritoModel carritoModel,int CodigoProducto)
        //{

        //    //recuperar el usuario de la sesion , traer su id 

        //    var ProductoEnviado  = produc.RecuperarPorId(CodigoProducto);

        //    carritoModel.CodigoProducto = CodigoProducto;

        //    return Json(ProductoEnviado);
        //}


        [HttpPost]
        public ActionResult AgregarCarrito(CarritoModel carritoModel)
        {
            //recuperar el usuario de la sesion , traer su id para agracarlo a carritoModel
            var nombre = Session["NombreUsuario"].ToString();
            var recupero = _servicioUsuario.RecuperarPorNombre(nombre);
             carritoModel.IdUsuario = recupero.IdUsuario;

            //Inserta productos en la Tabla carrito
            _serviciocarrito.InsertarEnCarrito(carritoModel);
            
            return Json("");


        }


        

        [HttpGet]
        public ActionResult Carrito(Pedido pedidos)
        {

            var nombre = Session["NombreUsuario"].ToString();
            var recupero = _servicioUsuario.RecuperarPorNombre(nombre);
            var us = recupero.IdUsuario;
            
            var car = _serviciocarrito.MostrarCarrito(us);

            
            

            return View(car);
           

        }   
        
        [HttpPost]
        public JsonResult Carrito(int itemid,string h)
        {
            return Json(data:"", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
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
        //recuperr el usuario
        private static Usuario recupero;
        



        public ActionResult Index()
        {
            //redirige login

            //if (Session["Rol"].ToString() == "2")
            var nombre = Session["NombreUsuario"].ToString();
             recupero = _servicioUsuario.RecuperarPorNombre(nombre);

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


        //agrega productos al carrito
        [HttpPost]
        public ActionResult AgregarCarrito(CarritoModel carritoModel)
        {
            //recuperar el usuario de la sesion , traer su id para agracarlo a carritoModel
            //var nombre = Session["NombreUsuario"].ToString();
            //var recupero = _servicioUsuario.RecuperarPorNombre(nombre);
             carritoModel.IdUsuario = recupero.IdUsuario;
            

            //Inserta productos en la Tabla carrito
            _serviciocarrito.InsertarEnCarrito(carritoModel);
            int _respuesta = 0;
            _respuesta = _serviciocarrito.RecuperarCantidad(recupero.IdUsuario);

            return Json(new { Cantidad = _respuesta });


        }


        
        //muesta la vista del carrito
        [HttpGet]
        public ActionResult Carrito()
        
        {
       
            var us = recupero.IdUsuario;
            
            //Le paso el id Usuario para traer la lista de su carrito
            var car = _serviciocarrito.MostrarCarrito(us);  

            return View(car);
           

        }


        [HttpPost]
        public ActionResult EliminarProductoCarrito(CarritoModel carritoModel)

        {

            //Le paso el codigodelProducto para eliminarlo
             _serviciocarrito.EliminarProductoCarrito(carritoModel.CodigoProducto);

            //recupero la cantidad del carrito para enviar al contador
            int _respuesta = 0;
            _respuesta = _serviciocarrito.RecuperarCantidad(recupero.IdUsuario);

            return Json(new { Cantidad = _respuesta }) ;
           


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


        [HttpGet]
        public JsonResult CantidadCarrito()
        {

            int _respuesta = 0;
            _respuesta = _serviciocarrito.RecuperarCantidad(recupero.IdUsuario);
            return Json(new { respuesta = _respuesta }, JsonRequestBehavior.AllowGet);
        }
 
    }
}
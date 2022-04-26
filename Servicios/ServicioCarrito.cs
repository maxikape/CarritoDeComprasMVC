using Daos.Daos;
using Daos.Interfaces;
using Entidades.Entidades;
using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
   public class ServicioCarrito
    {
        private ICarritoDao _carritoDao;
        public ServicioCarrito()
        {
            this._carritoDao = new CarritoDao();
        }



        public CarritoModel InsertarEnCarrito(CarritoModel carritoModel)
        {
            //tarigo la lista del carrito para comparar con el producto que intento agregar
            var listacarro = _carritoDao.MostrarCarrito(carritoModel.IdUsuario);
            //??
      
                foreach (var item in listacarro)
                {
                    if (item.CodigoProducto == carritoModel.CodigoProducto)
                    {
                        carritoModel.Cantidad = carritoModel.Cantidad + item.Cantidad;
                        _carritoDao.UpdateCarrito(item.CodigoProducto, carritoModel.Cantidad);
                        return carritoModel;
                    }
                }

            

       
                _carritoDao.InsertarEnCarrito(carritoModel);
                return carritoModel;
            
      

        }


        public List<CarritoModel> MostrarCarrito(int IdUsuario)
        {

           var listacarro= _carritoDao.MostrarCarrito(IdUsuario);
           
            ////Agrego el subtotal al objeto CarritoModel
            //for (int i = 0; i < listacarro.Count; i++)
            //{
            //    listacarro[i].Subtotal = listacarro[i].PrecioUnitario * listacarro[i].Cantidad;
            //}

            return listacarro;

        }

        //
        public bool EliminarProductoCarrito(int idCarrito) {

            _carritoDao.EliminarProductoCarrito(idCarrito);
            return true;
        
        }

        //recupero la cantidad del carro para sumar el Contador-carrito
        public int RecuperarCantidad(int id)
        {
            var cant = _carritoDao.RecuperarCantidad(id);
            return cant;

        }

    }
}

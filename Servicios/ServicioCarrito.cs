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

            _carritoDao.InsertarEnCarrito(carritoModel);
            return carritoModel;

        }


        public List<CarritoModel> MostrarCarrito(int IdUsuario)
        {

           var listacarro= _carritoDao.MostrarCarrito(IdUsuario);
            
            var Pedido = new Pedido();
            
            return listacarro;

        }

    }
}

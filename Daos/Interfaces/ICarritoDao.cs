using Entidades.Entidades;
using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daos.Interfaces
{
   
   public interface ICarritoDao
    {
        bool InsertarEnCarrito(CarritoModel carritoModel);
        List<CarritoModel> MostrarCarrito(int IdUsuario);
        bool EliminarProductoCarrito(int IdCarrito);
        int RecuperarCantidad(int id);
        bool UpdateCarrito(int car, int cant);
    }
}

using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daos.Interfaces
{
    public interface IProductoDao
    {

        List<Producto> Mostrar();

        List<Marca> MostrarMarcas();

        bool InsertarProducto(Producto producto);

        bool ModificarProducto(Producto producto);


        Producto RecuperarPorId(int id);
    }
}

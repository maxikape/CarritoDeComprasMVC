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
    public class ServicioProductos
    {
        private IProductoDao _productoDao;
        public ServicioProductos()
        {
            this._productoDao = new ProductoDao();
        }

        //lista productos para el Usuario
        public List<Producto> MostrarProductosUsuario()
        {
          var pro = _productoDao.Mostrar();

            return pro;
        }



        //lista productos para el admin
        public ListaProductosModel ListarProductosAdmin()
        {

            ListaProductosModel listaProd = new ListaProductosModel();
            var lista2 = new List<Producto>();

            var lista = _productoDao.Mostrar();
            for (int i = 0; i < lista.Count; i++)
            {
                Producto producto = new Producto();
                producto.Activo = lista[i].Activo;
                producto.CodigoProducto = lista[i].CodigoProducto;
                producto.Descripcion = lista[i].Descripcion;
                producto.IdMarca = lista[i].IdMarca;
                producto.Nombre = lista[i].Nombre;
                producto.NombreMarca = lista[i].NombreMarca;
                producto.PrecioUnitario = lista[i].PrecioUnitario;
                producto.UrlImage = lista[i].UrlImage;

                lista2.Add(producto);
            }

            listaProd.Productos = lista2;
  
            //ListarRoles(listaus);
            return listaProd;

        }


       // mostrar las marcas en el dropdowdlist
        public ListaProductosModel MostrarMarcas()
        {

      
                ListaProductosModel listamarcas = new ListaProductosModel();
                var lista2 = new List<Marca>();

                var lista = _productoDao.MostrarMarcas();
                for (int i = 0; i < lista.Count; i++)
                {
                    Marca marcas = new Marca();
                    marcas.IdMarca = lista[i].IdMarca;
                    marcas.NombreMarca = lista[i].NombreMarca;


                    lista2.Add(marcas);

                }
                listamarcas.Marcas = lista2;


                return listamarcas;

    

        }
        // insertar un nuevo producto por el administrador
        public Producto InsertarProducto(Producto producto)
        {
            _productoDao.InsertarProducto(producto);
            return producto;

        }


        public Producto ModificarProducto(Producto producto)
        {

            _productoDao.ModificarProducto(producto);
            return producto;

        }


       public Producto RecuperarPorId(int id)
        {
           var productos= _productoDao.RecuperarPorId(id);
            return productos;

        }



    }
}

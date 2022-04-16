using Daos.Interfaces;
using Dapper;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daos.Daos
{
    public class ProductoDao : DaoDb, IProductoDao
    {


        private const string qrMostrarProductos = @"select CodigoProducto, Nombre, UrlImage, m.NombreMarca, 
                                                            PrecioUnitario, Descripcion, Activo, m.IdMarca
                                                            FROM Productos a
                                                            JOIN Marcas as m on a.IdMarca = m.IdMarca";


        //Muestra el listado de todos los produsctos 
        public List<Producto> Mostrar()
        {
            var productos = new List<Producto>();

            try
            {
                using (var con = AbrirConexion())
                {
                    productos = con.Query<Producto>(qrMostrarProductos).AsList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return productos;
        }


        //Muestra la lista de marcas 
        private const string qrselectMarcas = @"select * from Marcas";

        public List<Marca> MostrarMarcas()
        {
            try
            {

                using (var con = AbrirConexion())
                {
                    return con.Query<Marca>(qrselectMarcas).AsList();

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //insertar un producto 
        private const string qrInsertProducto = @"INSERT INTO Productos(Nombre,Descripcion,PrecioUnitario,UrlImage,Activo,IdMarca) 
                                                Values(@nombre, @descripcion,@precioUnitario,@urlImage,@activo,@idMarca) ";

        public bool InsertarProducto(Producto producto)
        {

            try
            {
                int result = 0;
                using (var con = AbrirConexion())
                {

                    result = con.Execute(qrInsertProducto, new
                    {
                        nombre = producto.Nombre,
                        descripcion = producto.Descripcion,
                        precioUnitario = producto.PrecioUnitario,
                        urlImage = producto.UrlImage,
                        activo = producto.Activo,
                        idMarca = producto.IdMarca
                    });
                    return true;

                }

            }
            catch (Exception)
            {

                throw;
            }


        }


        private const string qrRecuperarPorId = @"select CodigoProducto, Nombre, UrlImage, m.NombreMarca, 
                                                            PrecioUnitario, Descripcion, Activo, m.IdMarca
                                                            FROM Productos a
                                                            JOIN Marcas as m on a.IdMarca = m.IdMarca
                                                            where CodigoProducto = @id";


        //devuelve un producto por su ID
        public Producto RecuperarPorId(int id)
        {
            

            try
            {
                using (var con = AbrirConexion())
                {
                  var  productos = con.QueryFirstOrDefault<Producto>(qrRecuperarPorId, param: new {id = id });
                   
                  return productos;
                }

               
            }

            catch (Exception)
            {

                throw;
            }

           
        }




        private const string qrModificarProducto = @"UPDATE Productos SET Nombre = @Nombre,
					                                                       Descripcion = @Descripcion,
					                                                       PrecioUnitario = @PrecioUnitario, 
					                                                       UrlImage = @UrlImage, 
					                                                       Activo = @Activo,
                                                                           IdMarca = @IdMarca
					                                                       Where CodigoProducto = @CodigoProducto";
        public bool ModificarProducto(Producto producto)
        {
            try
            {
                int result = 0;
                using (var con = AbrirConexion())
                {
                    result = con.Execute(qrModificarProducto, producto);
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


    }

}

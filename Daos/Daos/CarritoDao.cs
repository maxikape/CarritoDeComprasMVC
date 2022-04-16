using Daos.Interfaces;
using Dapper;
using Entidades.Entidades;
using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daos.Daos
{
    public class CarritoDao : DaoDb, ICarritoDao
    {

        //private const string qrMostrarDetallePedido = @" SELECT   CodigoCliente, d.NumeroItem,d.NumeroPedido,d.CodigoProducto,d.Cantitdad,d.PrecioUnitario
        //                                                      FROM Pedidos p
        //                                                            JOIN DetallesPedidos as d on p.NumeroPedido = d.NumeroPedido
        //                                                            where CodigoCliente = @idCodigoCliente
        //                                                                    ";




        ////Muestra el listado de todos los pedidos
        //public List<DetallePedido> pedido(int idCodigoCliente)
        //{
        //    var Pedidos = new List<DetallePedido>();

        //    try
        //    {
        //        using (var con = AbrirConexion())
        //        {
        //            Pedidos = con.Query<DetallePedido>(qrMostrarDetallePedido).AsList();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return Pedidos;
        //}
        private const string qrMostrarDetalleCarrito = @" SELECT    c.Id, c.IdUsuario, c.Cantidad, c.CodigoProducto
		                                                            FROM Carrito c
                                                                    JOIN Productos as p on c.CodigoProducto = p.CodigoProducto
                                                                    where c.IdUsuario = @IdUsuario ";

        //Muestra el listado de todos los pedidos
        public List<CarritoModel> MostrarCarrito(int IdUsuario)
        {
            var Pedidos = new List<CarritoModel>();

            try
            {
                using (var con = AbrirConexion())
                {
                    Pedidos = con.Query<CarritoModel>(qrMostrarDetalleCarrito , param: new { IdUsuario = IdUsuario }).AsList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Pedidos;
        }



        private const string qrInsertProducto = @"INSERT INTO Carrito(IdUsuario, Cantidad, CodigoProducto) 
                                                Values(@idUsuario, @cantidad, @codigoProducto) ";

        public bool InsertarEnCarrito(CarritoModel carritoModel)
        {

            try
            {
                int result = 0;
                using (var con = AbrirConexion())
                {

                    result = con.Execute(qrInsertProducto, new
                    {
                        idUsuario = carritoModel.IdUsuario,
                        cantidad = carritoModel.Cantidad,
                        codigoProducto = carritoModel.CodigoProducto


                    });
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

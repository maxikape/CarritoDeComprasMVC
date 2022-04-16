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
    public class UsuarioDao : DaoDb, IUsuarioDao
    {


        private const string qrRecuperarPorNombre = @"SELECT [IdUsuario]
              ,[IdRol]
                ,[NombreUsuario]
              
              ,[Nombre]
              ,[Apellido]
              ,[Password]
              ,[PasswordSalt]
              ,[FechaCreacion]
              ,[Activo]
                FROM Usuarios
            where Nombre =@nombre";


        //devuelve un Usuario por su Nombre
        public Usuario RecuperarPorNombre(string nombre)
        {


            try
            {
                using (var con = AbrirConexion())
                {
                    var Usuarios = con.QueryFirstOrDefault<Usuario>(qrRecuperarPorNombre, param: new { Nombre = nombre });

                    return Usuarios;
                }


            }

            catch (Exception)
            {

                throw;
            }


        }


    }
}

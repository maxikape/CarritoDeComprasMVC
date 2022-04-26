using Daos.Interfaces;
using Daos;
using Dapper;
using Entidades.Entidades;
using System;
using System.Collections.Generic;


namespace Daos.Daos
{
   public class LoginDao : DaoDb , ILoginDao
    {

        private const string qrselectUsuarios = @"select Usuario, Password from Usuarios where Usuario =@usuario and Password =@password";

        //login
        public List<Usuario> Login(string UserName, string Password)
        {
            try
            {
                using (var con = AbrirConexion())
                {          
                    return con.Query<Usuario>(qrselectUsuarios).AsList();
                    
                }

            }

            catch (Exception)
            {

                throw;
            }

        }


        private const string QrEncontrarUsuario = @"SELECT [IdUsuario]
                                              ,[IdRol]
                                              ,[NombreUsuario] 
                                              ,[Nombre]
                                              ,[Apellido]
                                              ,[Password]
                                              ,[PasswordSalt]
                                              ,[FechaCreacion]
                                              ,[Activo]
                                              FROM [Usuarios]
                                              where (NombreUsuario = @Usuario) and (Password =@Password)";

        public Usuario EncontrarUsuario(string Usuario, string Password)
        {
            
            try
            {
                    
                using (var con = AbrirConexion())   
                {
                    var us = con.QuerySingleOrDefault<Usuario>(QrEncontrarUsuario, param : new {Usuario, Password});

                    if (us != null)
                    {
                        return us;
                    }

                    else
                    {
                        return null;
                    } 

                }
            }

            catch (Exception ex)
            {

                throw ex;
               
            }

        }



 


        private const string qrInsertUsuario = @"INSERT INTO Usuarios(NombreUsuario,Nombre,Apellido,IdRol,Password,Activo) 

                                               Values(@nombreUsuario, @nombre,@apellido,@idRol,@password,@activo) ";


        private const string qrInserCliente = @"INSERT INTO Clientes(RazonSocial,IdUsuario) 

                                               Values(@razonSocial, @idUsuario) ";

        //insertar nuevo usuario para el login
        public bool InsertarUsuario(Usuario usuario)
        {

            try
            {
                int result = 0;
                using (var con = AbrirConexion())
                {
                    //inserto en la tabla usuario
                    result = con.Execute(qrInsertUsuario, new
                    {
                        nombreusuario = usuario.Nombre,
                        nombre = usuario.Nombre,
                        apellido = usuario.Apellido,
                        idRol = 2,
                        password = usuario.Password,
                        //fechaCreacion = usuario.FechaCreacion,
                        activo = usuario.Activo
                    });

                   ////var  user = UsuarioDao.RecuperarPorNombre( Convert.ToString(usuario.Nombre));
                   // //inserto en la tabla cliente
                   // result = con.Execute(qrInserCliente, new
                   // {
                   //     razonSocial=usuario.RazonSocial,
                   //     //fechaCreacion= usuario.FechaCreacion,
                   //     idUsuario= usuario.IdUsuario
              
                   // });
                    return true;

                    

                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        //insertar nuevo usuario para el login
        public bool InsertarCliente(Usuario usuario)
        {

            try
            {
                int result = 0;
                using (var con = AbrirConexion())
                {


                    //var  user = UsuarioDao.RecuperarPorNombre( Convert.ToString(usuario.Nombre));
                    //inserto en la tabla cliente
                    result = con.Execute(qrInserCliente, new
                    {
                        razonSocial = usuario.RazonSocial,
                        //fechaCreacion= usuario.FechaCreacion,
                        idUsuario = usuario.IdUsuario

                    });
                    return true;



                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        //private const string QrRolUsuario = @"select* from Roles
        //                                     INNER JOIN Usuarios
        //                                     ON Roles.IdRol = Usuarios.IdRol
        //                                     where (Roles.IdRol = @id);";



        //public bool RolUsuario(string id)
        //{

        //    try
        //    {


        //        using (var con = AbrirConexion())
        //        {
        //            var us = con.QuerySingleOrDefault<Usuario>(QrRolUsuario, param: new { id });

        //            if (us != null)
        //            {
        //                return true;
        //            }

        //            else
        //            {
        //                return false;
        //            }

        //        }
        //    }

        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}


    }
}

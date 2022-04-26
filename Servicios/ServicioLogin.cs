using Daos.Daos;
using Daos.Interfaces;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioLogin
    {
        private ILoginDao _LoginDao;
        private IUsuarioDao _usuarioDao;
        public ServicioLogin()
        {
            this._LoginDao = new LoginDao();
            this._usuarioDao = new UsuarioDao();
        }

        public Usuario Login(string Usuario, string Password)
        {
            var a = _LoginDao.EncontrarUsuario(Usuario, Password);
            return a;
        }



        public bool InsertarUsuario(Usuario usuario)
        {
           
            var us = _LoginDao.InsertarUsuario(usuario);


            return us;
        }
        
        public bool InsertarCliente(Usuario usuario)
        {
            //recupoero el IdUsuario que se creo con el metodo anterior InsertarUsuario()
            var recuperarIdUsuario = _usuarioDao.RecuperarPorNombre(usuario.Nombre);
            //le asigno el IdUsuario para pasarselo al nuevo modelo que inserta el cliente
            usuario.IdUsuario = recuperarIdUsuario.IdUsuario;
            //inserto el cliente
            var us = _LoginDao.InsertarCliente(usuario);

        return us;
        }


    }

}

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
   public class ServicioUsuario
    {
         private IUsuarioDao _usuarioDao;
        public ServicioUsuario()
        {
            this._usuarioDao = new UsuarioDao();
        }

        //recupera el objeto usuario apartir de el nombre de la sesion 
        public Usuario RecuperarPorNombre(string nombre)
        {
           var us = _usuarioDao.RecuperarPorNombre(nombre);

            return us;
        }

    }
}

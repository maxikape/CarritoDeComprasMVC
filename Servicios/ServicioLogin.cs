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
        public ServicioLogin()
        {
            this._LoginDao = new LoginDao();
        }

        public Usuario Login(string Usuario, string Password)
        {
            var a = _LoginDao.EncontrarUsuario(Usuario, Password);
            return a;
        }





    }

}

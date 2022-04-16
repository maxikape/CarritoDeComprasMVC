using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daos.Interfaces
{
    public interface IUsuarioDao
    {
       
        Usuario RecuperarPorNombre(string nombre);

    }
}

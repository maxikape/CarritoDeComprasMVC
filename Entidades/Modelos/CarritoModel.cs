using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class CarritoModel
    {

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
    }


}

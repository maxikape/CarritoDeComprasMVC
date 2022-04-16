using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
   public class DetallePedido
    {
        public int NumeroItem { get; set; }
        public int NumeroPedido { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }

    }
}

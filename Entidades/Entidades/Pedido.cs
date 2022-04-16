using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
   public class Pedido
    {

        
        public int NumeroPedido { get; set; }
        public int CodigoCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }

        public List<DetallePedido> DetallePedidos { get; set; }



    }
}

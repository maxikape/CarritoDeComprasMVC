using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class ListaProductosModel
    {
        public List<Producto> Productos { get; set; }
        public List<Marca> Marcas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entidades.Entidades
{
    public class Producto
    {

        [Display(Name ="Código")]
        public int CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdMarca { get; set; }
        public int PrecioUnitario { get; set; }
        public bool Activo { get; set; }
        public string UrlImage { get; set; }
        [Display(Name ="Imagen")]
        public HttpPostedFileBase img { get; set; }

        public string NombreMarca { get; set; }

        public Marca Marcas = new Marca();


    }
}

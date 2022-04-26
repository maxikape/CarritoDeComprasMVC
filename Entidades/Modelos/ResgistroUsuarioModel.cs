using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class ResgistroUsuarioModel
    {
        public int IdUsuario { get; set; }

        public int IdRol { get; set; }

        public string DescripcionRol { get; set; }

        [Display(Name = "Email")]
        public string NombreUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        [Required(ErrorMessage = "Please enter password")]

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int Activo { get; set; }

        

    }
}

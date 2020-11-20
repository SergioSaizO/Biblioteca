using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class AppUser: IdentityUser
    {
       /*public int Id;*/ /*El Id lo coge de la identity*/
       public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set;} 
        public string Imagen { get; set; }

        public List<ClienteLibro> CLienteLibros { get; set; }



    }
}

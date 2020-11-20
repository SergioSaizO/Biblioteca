using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class ClienteLibro
    {
        public int Id { get; set; }
        public int CLienteId { get; set; }
        
        public int LibroId { get; set; }

        
        public AppUser User { get; set; }

        public Libro Libro { get; set; }




        

    }
}

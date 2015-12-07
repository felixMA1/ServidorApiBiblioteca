using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServidorApiBiblioteca.Models
{
    public class Libro
    {
        public int cod_libro { get; set; }
        public string nombre { get; set; }
        public string editorial { get; set; }
        public string autor { get; set; }
        public string genero { get; set; }
        public decimal precio { get; set; }

    }
}
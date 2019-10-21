using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultaClimaApp.Models
{
    public class Favorito
    {
        public int IdCidade { get; set; }
        public string NomeCidade { get; set; }
        public string Clima { get; set; }
        public string Temperatura { get; set; }
    }
}

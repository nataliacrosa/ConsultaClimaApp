using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultaClimaApp.Models
{
    public class ListaCidade
    {
        public List<Cidade> data { get; set; }
    }
    public class Cidade
    {
        public int id { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public string name { get; set; }
        public int zoom { get; set; }
    }
}

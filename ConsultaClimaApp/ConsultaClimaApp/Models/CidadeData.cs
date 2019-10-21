using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsultaClimaApp.Models
{
    public static class CidadeData
    {
        public static IList<Cidade> Cidades { get; private set; }

        static CidadeData()
        {
            Cidades = new List<Cidade>();

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Cidade)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("ConsultaClimaApp.city.list.json");

            using (var reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                ListaCidade cidades = JsonConvert.DeserializeObject<ListaCidade>(json);

                foreach (var cidade in cidades.data)
                {
                    Cidades.Add(cidade);
                }
            }

            Cidades = Cidades.OrderBy(cidade => cidade.name).ToList();
        }
    }
}

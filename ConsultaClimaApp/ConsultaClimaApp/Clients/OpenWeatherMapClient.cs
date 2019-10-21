using ConsultaClimaApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ConsultaClimaApp.Clients
{
    public static class OpenWeatherMapClient
    {
        public static Clima BuscarClima(int idCidade)
        {
            try
            {
                StringBuilder urlApi = new StringBuilder();
                string response = string.Empty;

                urlApi.Append("http://api.openweathermap.org/data/2.5/weather?id=");
                urlApi.AppendFormat("{0}", idCidade);
                urlApi.Append("&appid=2bac87e0cb16557bff7d4ebcbaa89d2f&lang=pt&units=metric");

                HttpWebRequest request = WebRequest.Create(urlApi.ToString()) as HttpWebRequest;                

                using (HttpWebResponse httpWebResponse = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream());
                    response = reader.ReadToEnd();
                }

                Clima responseDeserializado = JsonConvert.DeserializeObject<Clima>(response);

                return responseDeserializado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

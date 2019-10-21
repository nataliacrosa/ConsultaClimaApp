using ConsultaClimaApp.Models;
using ConsultaClimaApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ConsultaClimaApp.ViewModels
{
    sealed class DetalheCidadeViewModel : ViewModelBase
    {
        private int _IdCidade;
        private string _NomeCidade;
        private string _Temperatura;
        private string _DescricaoTempo;
        private string _TemperaturaMinima;
        private string _TemperaturaMaxima;

        public DetalheCidadeViewModel() : base() { }
        public DetalheCidadeViewModel(Clima clima)
        {
            IdCidade = clima.id;
            NomeCidade = clima.name;
            Temperatura = string.Concat(clima.main.temp.ToString("F0"), " °C");
            DescricaoTempo = clima.weather.FirstOrDefault().description;
            TemperaturaMinima = string.Concat(clima.main.temp_min.ToString("F0"), " °C"); ;
            TemperaturaMaxima = string.Concat(clima.main.temp_max.ToString("F0"), " °C"); ;
        }

        public int IdCidade { get => _IdCidade; set { _IdCidade = value; OnPropertyChanged(); } }
        public string NomeCidade { get => _NomeCidade; set { _NomeCidade = value; OnPropertyChanged(); } }
        public string Temperatura { get => _Temperatura; set { _Temperatura = value; OnPropertyChanged(); } }
        public string DescricaoTempo { get => _DescricaoTempo; set { _DescricaoTempo = value; OnPropertyChanged(); } }
        public string TemperaturaMinima { get => _TemperaturaMinima; set { _TemperaturaMinima = value; OnPropertyChanged(); } }
        public string TemperaturaMaxima { get => _TemperaturaMaxima; set { _TemperaturaMaxima = value; OnPropertyChanged(); } }
    }
}

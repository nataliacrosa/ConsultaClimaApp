using ConsultaClimaApp.Models;
using ConsultaClimaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsultaClimaApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheCidadePage : ContentPage
    {
        public DetalheCidadePage(Clima clima)
        {
            InitializeComponent();

            BindingContext = new DetalheCidadeViewModel(clima);
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var idCidade = lblIdCidade.Text;
            var nomeCidade = lblNomeCidade.Text;
            var temperatura = lblTemperatura.Text;
            var descricao = lblDescricaoTempo.Text;

            var query = $"INSERT INTO Favoritos (IdCidade, NomeCidade, Clima, Temperatura) VALUES ({idCidade}, '{nomeCidade}', '{descricao}', '{temperatura}')";
            ((App)Application.Current).Conexao.Execute(query);
            //CarregarInformacoes();
        }
    }
}
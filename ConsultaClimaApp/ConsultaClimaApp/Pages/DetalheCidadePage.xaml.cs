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

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var idCidade = lblIdCidade.Text;
            var nomeCidade = lblNomeCidade.Text;
            var temperatura = lblTemperatura.Text;
            var descricao = lblDescricaoTempo.Text;

            var favorito = ((App)Application.Current).Conexao.Query<Clima>($"SELECT * from Favoritos WHERE IdCidade = {idCidade}");
            if (favorito.Count == 0)
            {
                var query = $"INSERT INTO Favoritos (IdCidade, NomeCidade, Clima, Temperatura) VALUES ({idCidade}, '{nomeCidade}', '{descricao}', '{temperatura}')";
                ((App)Application.Current).Conexao.Execute(query);
                await Navigation.PushAsync(new CidadeFavoritaPage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Olá!", "Você já favoritou essa cidade.", "Ok");
            }
        }
    }
}
using ConsultaClimaApp.Clients;
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
    public partial class CidadeFavoritaPage : ContentPage
    {
        public CidadeFavoritaPage()
        {
            InitializeComponent();
            CarregarInformacoes();
            BindingContext = new CidadeFavoritaViewModel();

        }

        async void CarregarInformacoes()
        {
            var list = ((App)Application.Current).Conexao.Query<Favorito>("SELECT IdCidade, NomeCidade, Clima, Temperatura from Favoritos");
            if (list.Count == 0)
            {
                await DisplayAlert("Olá!", "Você ainda não possui registros nos favoritos", "Ok");
            }
            else
            {
                ListView.ItemsSource = list;
            }
        }

        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var favorito = e.SelectedItem as Favorito;
            var clima = OpenWeatherMapClient.BuscarClima(favorito.IdCidade);

            await Navigation.PushAsync(new DetalheCidadePage(clima));
        }
    }
}
using ConsultaClimaApp.Models;
using ConsultaClimaApp.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ConsultaClimaApp.ViewModels
{
    sealed class CidadeFavoritaViewModel : ViewModelBase
    {
        public CidadeFavoritaViewModel() : base() { }

        public Command _BuscarCommand;
        public Command BuscarCommand => _BuscarCommand ?? (_BuscarCommand = new Command( async () => await PushAsync(new SelecaoCidadePage())));
        async void CarregarInformacoes()
        {
            var list = ((App)Application.Current).Conexao.Query<Clima>("SELECT * from Favoritos");
            if (list.Count == 0)
            {
                await App.Current.MainPage.DisplayAlert("Olá!", "Você ainda não possui registros nos favoritos", "Ok");
            }
            //await ListView.ItemsSource = list;
        }
    }
}


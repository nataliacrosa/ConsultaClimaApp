using ConsultaClimaApp.Clients;
using ConsultaClimaApp.Models;
using ConsultaClimaApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsultaClimaApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelecaoCidadePage : ContentPage
    {
        public SelecaoCidadePage()
        {
            InitializeComponent();
            BindingContext = new SelecaoCidadeViewModel();
        }

        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var cidade = e.SelectedItem as Cidade;
            var clima = OpenWeatherMapClient.BuscarClima(cidade.id);

            await Navigation.PushAsync(new DetalheCidadePage(clima));
        }

        void OnTap(object sender, ItemTappedEventArgs e)
        {
        }        
    }
}
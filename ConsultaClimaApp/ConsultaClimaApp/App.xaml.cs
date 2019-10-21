using ConsultaClimaApp.Pages;
using PCLExt.FileStorage.Folders;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsultaClimaApp
{
    public partial class App : Application
    {
        public SQLiteConnection Conexao { get; private set; }
        public App()
        {
            var pasta = new LocalRootFolder();
            var arquivo = pasta.CreateFile("ConsultaClimaApp.db", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);
            Conexao = new SQLiteConnection(arquivo.Path);
            Conexao.Execute("CREATE TABLE IF NOT EXISTS Favoritos (Id INTEGER PRIMARY KEY AUTOINCREMENT, IdCidade INTEGER, NomeCidade TEXT, Clima TEXT, Temperatura TEXT)");

            InitializeComponent();

            MainPage = new NavigationPage(new CidadeFavoritaPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

using ConsultaClimaApp.Models;
using System.Collections.Generic;

namespace ConsultaClimaApp.ViewModels
{
    sealed class SelecaoCidadeViewModel : ViewModelBase
    {
        public IList<Cidade> Cidades { get { return CidadeData.Cidades; } }

        Cidade selectedCidade;

        public SelecaoCidadeViewModel() : base() { }
        public Cidade SelectedCidade
        {
            get { return selectedCidade; }
            set
            {
                if (selectedCidade != value)
                {
                    selectedCidade = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

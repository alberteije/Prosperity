using System;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class GraficosFilterPage : ContentPage
	{

        public string Filtro;

        public GraficosFilterPage()
		{
			InitializeComponent();
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine(mesAnoDatePicker.Date);
        }

        protected override async void OnAppearing()
		{
			base.OnAppearing();
        }

        async void OnReceitasClicked(object sender, EventArgs e)
        {
            try
            {
                // Configura o filtro
                Filtro = "[MesAno] = '" + mesAnoDatePicker.Date.ToString("MM/yyyy") + "'";

                await Navigation.PushAsync(new GraficosListPage
                {
                    Filtro = Filtro,
                    MesAno = mesAnoDatePicker.Date.ToString("MM/yyyy"),
                    TipoGrafico = "Receitas"
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        async void OnDespesasClicked(object sender, EventArgs e)
        {
            try
            {
                // Configura o filtro
                Filtro = "[MesAno] = '" + mesAnoDatePicker.Date.ToString("MM/yyyy") + "'";

                await Navigation.PushAsync(new GraficosListPage
                {
                    Filtro = Filtro,
                    MesAno = mesAnoDatePicker.Date.ToString("MM/yyyy"),
                    TipoGrafico = "Despesas"
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

    }
}

using System;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class ResumoMensalFilterPage : ContentPage
	{

        public string Filtro;

        public ResumoMensalFilterPage()
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

        async void OnFiltrarClicked(object sender, EventArgs e)
        {
            try
            {
                // Configura o filtro
                Filtro = "[MesAno] = '" + mesAnoDatePicker.Date.ToString("MM/yyyy") + "'";

                await Navigation.PushAsync(new ResumoMensalListPage
                {
                    Filtro = Filtro,
                    MesAno = mesAnoDatePicker.Date.ToString("MM/yyyy")
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

    }
}

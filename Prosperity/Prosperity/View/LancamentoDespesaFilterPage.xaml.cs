using Models;
using System;
using System.Collections;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class LancamentoDespesaFilterPage : ContentPage
	{

        public string Filtro;
        public IList ListaContaDespesa;

        public LancamentoDespesaFilterPage()
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

            if (ListaContaDespesa == null)
            {
                ListaContaDespesa = await App.ContaDespesaDB.GetItemsAsync();
                foreach (ContaDespesa conta in ListaContaDespesa)
                {
                    listaContaDespesa.Items.Add(conta.CodigoDescricao);
                    /**
                     * Remova para produção
                     */
                    System.Diagnostics.Debug.WriteLine(conta.CodigoDescricao);
                }
            }

            listaContaDespesa.SelectedIndex = -1;
        }

        async void OnFiltrarClicked(object sender, EventArgs e)
        {
            // Configura o filtro
            Filtro = "[MesAno] = '" + mesAnoDatePicker.Date.ToString("MM/yyyy") + "'";
            
            if (listaContaDespesa.SelectedIndex >= 0)
            {
                Filtro = Filtro + " and [Codigo] = '" + listaContaDespesa.Items[listaContaDespesa.SelectedIndex].Substring(0, 4) + "'";
            }

            await Navigation.PushAsync(new LancamentoDespesaListPage {
                Filtro = Filtro,
                MesAno = "Mês/Ano: " + mesAnoDatePicker.Date.ToString("MM/yyyy")
            });
        }
    }
}

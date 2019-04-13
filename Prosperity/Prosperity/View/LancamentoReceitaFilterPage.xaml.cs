using Models;
using System;
using System.Collections;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class LancamentoReceitaFilterPage : ContentPage
	{

        public string Filtro;
        public IList ListaContaReceita;

        public LancamentoReceitaFilterPage()
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

            if (ListaContaReceita == null)
            {
                ListaContaReceita = await App.ContaReceitaDB.GetItemsAsync();
                foreach (ContaReceita conta in ListaContaReceita)
                {
                    listaContaReceita.Items.Add(conta.CodigoDescricao);
                    /**
                     * Remova para produção
                     */
                    System.Diagnostics.Debug.WriteLine(conta.CodigoDescricao);
                }
            }

            listaContaReceita.SelectedIndex = -1;
        }

        async void OnFiltrarClicked(object sender, EventArgs e)
        {
            // Configura o filtro
            Filtro = "[MesAno] = '" + mesAnoDatePicker.Date.ToString("MM/yyyy") + "'";
            
            if (listaContaReceita.SelectedIndex >= 0)
            {
                Filtro = Filtro + " and [Codigo] = '" + listaContaReceita.Items[listaContaReceita.SelectedIndex].Substring(0, 4) + "'";
            }

            await Navigation.PushAsync(new LancamentoReceitaListPage {
                Filtro = Filtro,
                MesAno = "Mês/Ano: " + mesAnoDatePicker.Date.ToString("MM/yyyy")
            });
        }
    }
}

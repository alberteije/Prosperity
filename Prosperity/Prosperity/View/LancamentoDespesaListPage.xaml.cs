using Models;
using Prosperity.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace Prosperity.View
{
	public partial class LancamentoDespesaListPage : ContentPage
	{

        public string Filtro;
        public string MesAno;
        public IList ListaTotaisLancamento;
        private Decimal TotalPago, TotalAPagar, Total;

        public LancamentoDespesaListPage()
		{
			InitializeComponent();
        }

        protected override async void OnAppearing()
		{
			base.OnAppearing();

            labelTitulo.Text = MesAno;

            listView.ItemsSource = await App.LancamentoDespesaDB.GetItemsAsyncFilter(Filtro);
            //listView.ItemsSource = await App.LancamentoDespesaDB.GetItemsAsync();

            /**
             * EXERCICIO: estude uma maneira de pegar esses totais sem a necessidade 
             * dessa nova lista e desse laço
             */

            TotalPago = 0;
            TotalAPagar = 0;
            Total = 0;

            ListaTotaisLancamento = await App.LancamentoDespesaDB.GetItemsAsyncFilter(Filtro);
            foreach (LancamentoDespesa lancamento in ListaTotaisLancamento)
            {
                if (lancamento.Situacao == 0)
                {
                    TotalPago = TotalPago + lancamento.Valor;
                }
                else if (lancamento.Situacao == 1)
                {
                    TotalAPagar = TotalAPagar + lancamento.Valor;
                }

                Total = Total + lancamento.Valor;
            }

            labelPago.Text = "Pago: " + TotalPago.ToString("R$ #,##0.00");
            labelAPagar.Text = "A Pagar: " + TotalAPagar.ToString("R$ #,##0.00");
            labelTotal.Text = "Total: " + Total.ToString("R$ #,##0.00");
        }

        async void OnItemAdded(object sender, EventArgs e)
		{
            try { 
			    await Navigation.PushAsync(new LancamentoDespesaPage
			    {
				    BindingContext = new LancamentoDespesa { DataDespesa = DateTime.Now }
                });
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new LancamentoDespesaPage
                {
                    BindingContext = e.SelectedItem as LancamentoDespesa
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

    }
}

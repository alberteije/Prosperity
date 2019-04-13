using Models;
using System;
using System.Collections;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class LancamentoReceitaListPage : ContentPage
	{

        public string Filtro;
        public string MesAno;
        public IList ListaTotaisLancamento;
        private Decimal TotalRecebido, TotalAReceber, Total;

        public LancamentoReceitaListPage()
		{
			InitializeComponent();
        }

        protected override async void OnAppearing()
		{
			base.OnAppearing();

            labelTitulo.Text = MesAno;

            listView.ItemsSource = await App.LancamentoReceitaDB.GetItemsAsyncFilter(Filtro);
            //listView.ItemsSource = await App.LancamentoReceitaDB.GetItemsAsync();

            /**
             * EXERCICIO: estude uma maneira de pegar esses totais sem a necessidade 
             * dessa nova lista e desse laço
             */

            TotalRecebido = 0;
            TotalAReceber = 0;
            Total = 0;

            ListaTotaisLancamento = await App.LancamentoReceitaDB.GetItemsAsyncFilter(Filtro);
            foreach (LancamentoReceita lancamento in ListaTotaisLancamento)
            {
                if (lancamento.Situacao == 0)
                {
                    TotalRecebido = TotalRecebido + lancamento.Valor;
                }
                else if (lancamento.Situacao == 1)
                {
                    TotalAReceber = TotalAReceber + lancamento.Valor;
                }

                Total = Total + lancamento.Valor;
            }

            labelRecebido.Text = "Recebido: " + TotalRecebido.ToString("R$ #,##0.00");
            labelAReceber.Text = "A Receber: " + TotalAReceber.ToString("R$ #,##0.00");
            labelTotal.Text = "Total: " + Total.ToString("R$ #,##0.00");
        }

        async void OnItemAdded(object sender, EventArgs e)
		{
            try { 
			    await Navigation.PushAsync(new LancamentoReceitaPage
			    {
				    BindingContext = new LancamentoReceita { DataReceita = DateTime.Now }
                });
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new LancamentoReceitaPage
            {
                BindingContext = e.SelectedItem as LancamentoReceita
            });            
        }

    }
}

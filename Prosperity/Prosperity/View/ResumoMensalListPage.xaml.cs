using Models;
using System;
using System.Collections;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class ResumoMensalListPage : ContentPage
    {

        public string Filtro;
        public string MesAno;

        public IList ListaLancametosReceita;
        public IList ListaLancametosReceitaAgrupado;
        public IList ListaLancametosDespesa;
        private Decimal TotalCredito, TotalDebito;

        public ResumoMensalListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            labelTitulo.Text = "Mês/Ano: " + MesAno;

            try
            {
                //Exibe as receitas agrupadas
                listViewReceitas.ItemsSource = await App.LancamentoReceitaDB.GetItemsAsyncFilterAgrupado(MesAno);

                // Total de Receitas
                TotalCredito = 0;
                ListaLancametosReceita = await App.LancamentoReceitaDB.GetItemsAsyncFilterAgrupado(MesAno);
                foreach (LancamentoReceitaAgrupado lancamento in ListaLancametosReceita)
                {
                    TotalCredito = TotalCredito + lancamento.Valor;
                }
                labelTotalReceitas.Text = "Total de Receitas: " + TotalCredito.ToString("R$ #,##0.00");


                //Exibe as despesas agrupadas
                listViewDespesas.ItemsSource = await App.LancamentoDespesaDB.GetItemsAsyncFilterAgrupado(MesAno);

                // Total de Despesas
                TotalDebito = 0;
                ListaLancametosDespesa = await App.LancamentoDespesaDB.GetItemsAsyncFilterAgrupado(MesAno);
                foreach (LancamentoDespesaAgrupado lancamento in ListaLancametosDespesa)
                {
                    TotalDebito = TotalDebito + lancamento.Valor;
                }
                labelTotalDespesas.Text = "Total de Despesas: " + TotalDebito.ToString("R$ #,##0.00");

                labelSaldo.Text = "Saldo: " + (TotalCredito - TotalDebito).ToString("R$ #,##0.00");

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

   }
}

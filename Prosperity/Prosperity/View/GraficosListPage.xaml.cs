using Microcharts;
using Models;
using SkiaSharp;
using System;
using System.Collections;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class GraficosListPage : ContentPage
    {

        public string Filtro;
        public string MesAno;
        public string TipoGrafico;

        public IList ListaLancametosReceita;
        public IList ListaLancametosDespesa;

        public GraficosListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            labelTitulo.Text = "Mês/Ano: " + MesAno;

            try
            {
                Microcharts.Entry[] entries = new Microcharts.Entry[0]; 
                String[] Cores = { "#90D585", "#68B9C0", "#266489", "#e60000", "#0040ff",
                    "#bf00ff", "#ff00ff", "#bfff00", "#ffff00", "#ffbf00", "#ff8000",
                    "#4d0000", "#ffe6e6", "#990000", "#aa948b", "#1a5c5a" };
                var i = 0;

                if (TipoGrafico == "Receitas")
                {
                    //Pega as receitas agrupadas
                    ListaLancametosReceita = await App.LancamentoReceitaDB.GetItemsAsyncFilterAgrupado(MesAno);
                    entries = new Microcharts.Entry[ListaLancametosReceita.Count];
                    foreach (LancamentoReceitaAgrupado lancamento in ListaLancametosReceita)
                    {
                        entries[i] = new Microcharts.Entry((float)lancamento.Valor)
                        {
                            Label = lancamento.Descricao,
                            ValueLabel = lancamento.Valor.ToString(),
                            Color = SKColor.Parse(Cores[i] != null ? Cores[i] : Cores[0])
                        };
                        i++;
                    }
                } 
                else if (TipoGrafico == "Despesas")
                {
                    //Pega as Despesas agrupadas
                    ListaLancametosDespesa = await App.LancamentoDespesaDB.GetItemsAsyncFilterAgrupado(MesAno);
                    entries = new Microcharts.Entry[ListaLancametosDespesa.Count];
                    foreach (LancamentoDespesaAgrupado lancamento in ListaLancametosDespesa)
                    {
                        entries[i] = new Microcharts.Entry((float)lancamento.Valor)
                        {
                            Label = lancamento.Descricao,
                            ValueLabel = lancamento.Valor.ToString(),
                            Color = SKColor.Parse(Cores[i] != null ? Cores[i] : Cores[0])
                        };
                        i++;
                    }
                }

                var chart = new DonutChart() { Entries = entries };
                chart.LabelTextSize = 50;
                this.chartView.Chart = chart;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }


            /*
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
            */
        }

   }
}

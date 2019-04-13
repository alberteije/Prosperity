using EasyFarm.OFX;
using Models;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class ExtratoBancarioListPage : ContentPage
    {

        public string Filtro;
        public string MesAno;
        public FileData filedata;
        public OfxDocument documentOFX;
        public bool SelecionouOFX;

        NumberStyles style;
        CultureInfo provider;

        public IList ListaTotaisExtrato;
        private Decimal TotalCredito, TotalDebito, Saldo;

        public ExtratoBancarioListPage()
        {
            InitializeComponent();
            style = NumberStyles.Number;
            provider = new CultureInfo("en-US");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            labelTitulo.Text = "Mês/Ano: " + MesAno;

            //se não tiver selecionado o arquivo
            //verifica se tem dados no banco
            //se tiver carrega os dados na tela
            if (SelecionouOFX == false)
            {
                CarregarDadosBanco();
            }
            else
            {
                //se tiver selecionado o arquivo
                //apaga os dados no banco para o mês selecionado
                //persiste os dados no banco
                //carrega os dados do arquivo na tela

                try
                {
                    Stream stream = new MemoryStream(filedata.DataArray);
                    documentOFX = new OfxDocument(stream);

                    await App.ExtratoBancoDB.DeleteAsyncFilter(Filtro);

                    foreach (Transaction trans in documentOFX.Transactions)
                    {
                        // Novo objeto para inserção
                        var extratoBanco = new ExtratoBanco();

                        // Informa os dados para o objeto
                        extratoBanco.MesAno = MesAno;
                        extratoBanco.DataTransacao = DateTime.Parse(trans.DatePosted.Substring(0, 4) + '-' + trans.DatePosted.Substring(4, 2) + '-' + trans.DatePosted.Substring(6, 2));
                        extratoBanco.Valor = Decimal.Parse(trans.TransAmount, style, provider);
                        extratoBanco.IdTransacao = trans.FITID;
                        extratoBanco.CheckNum = trans.CheckNum;
                        extratoBanco.NumeroReferencia = trans.FITID;
                        extratoBanco.Historico = trans.Memo;
                        extratoBanco.Conciliado = trans.TransAmount.Substring(0, 1);

                        // Persiste o objeto no banco de dados
                        await App.ExtratoBancoDB.SaveItemAsync(extratoBanco);
                    }

                    // Carrega os dados do banco na tela
                    CarregarDadosBanco();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }

        async void CarregarDadosBanco()
        {
            listView.ItemsSource = await App.ExtratoBancoDB.GetItemsAsyncFilter(Filtro);

            /**
             * EXERCICIO: estude uma maneira de pegar esses totais sem a necessidade 
             * dessa nova lista e desse laço
             */

            TotalCredito = 0;
            TotalDebito = 0;
            Saldo = 0;

            ListaTotaisExtrato = await App.ExtratoBancoDB.GetItemsAsyncFilter(Filtro);
            foreach (ExtratoBanco lancamento in ListaTotaisExtrato)
            {
                if (lancamento.Conciliado == "-")
                {
                    TotalDebito = TotalDebito + lancamento.Valor;
                }
                else
                {
                    TotalCredito = TotalCredito + lancamento.Valor;
                }
                Saldo = Saldo + lancamento.Valor;
            }

            labelTotalCredito.Text = "Créditos: " + TotalCredito.ToString("R$ #,##0.00");
            labelTotalDebito.Text = "Débitos: " + TotalDebito.ToString("R$ #,##0.00");
            labelSaldo.Text = "Saldo: " + Saldo.ToString("R$ #,##0.00");
        }

        async void OnExportItems(object sender, EventArgs e)
        {
            try {
                bool okResponse = await DisplayAlert("Exportar Dados",
                "Deseja exportar os dados como Lançamentos de Receita e Despesa?",
                "Sim", "Não");
                if (okResponse)
                {

                    foreach (ExtratoBanco lancamento in ListaTotaisExtrato)
                    {

                        // Verifica se é um lançamento de receita ou de despesa
                        if (lancamento.Conciliado == "-")
                        {

                            // Novo objeto para inserção
                            LancamentoDespesa lancamentoDespesa = new LancamentoDespesa();

                            // Informa os dados para o objeto
                            lancamentoDespesa.MesAno = MesAno;
                            lancamentoDespesa.DataDespesa = lancamento.DataTransacao;
                            lancamentoDespesa.Historico = lancamento.Historico;
                            lancamentoDespesa.Valor = lancamento.Valor * -1;

                            // Persiste o objeto no banco de dados
                            await App.LancamentoDespesaDB.SaveItemAsync(lancamentoDespesa);
                        }
                        else
                        {
                            // Novo objeto para inserção
                            LancamentoReceita lancamentoReceita = new LancamentoReceita();

                            // Informa os dados para o objeto
                            lancamentoReceita.MesAno = MesAno;
                            lancamentoReceita.DataReceita = lancamento.DataTransacao;
                            lancamentoReceita.Historico = lancamento.Historico;
                            lancamentoReceita.Valor = lancamento.Valor;

                            // Persiste o objeto no banco de dados
                            await App.LancamentoReceitaDB.SaveItemAsync(lancamentoReceita);
                        }

                    }

                    await DisplayAlert("Exportar Dados", "Dados Exportados com Sucesso!", "OK");
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

   }
}

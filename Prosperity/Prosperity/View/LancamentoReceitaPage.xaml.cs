using Models;
using System;
using System.Collections;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class LancamentoReceitaPage : ContentPage
	{
        public IList ListaContaReceita;

        public LancamentoReceitaPage()
		{
            InitializeComponent();
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
                }
            }

            /**
             * Aqui faremos uma consulta para pegar o conteúdo do campo CodigoDescricao
             * que foi previamente armazenado no banco de dados. Nesse momento temos apenas
             * o código e dessa maneira não tem como selecionarmos o valor do Picker apenas
             * com essa informação.
             * 
             * Utilize o link seguinte para saber como usar a versão mais recente do
             * Xamarin.Forms utilizando a propriedade ItemsSource e os Bindings.
             * Tente implementar dessa outra maneira.
             * 
             * https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/picker/
             */

            var lancamentoReceita = (LancamentoReceita)BindingContext;
            if (lancamentoReceita.Codigo != null)
            {
                var contaReceita = await App.ContaReceitaDB.GetItemPorCodigoAsync(lancamentoReceita.Codigo);
                int IndiceQueSeraSelecionado = listaContaReceita.Items.IndexOf(contaReceita.CodigoDescricao);
                listaContaReceita.SelectedIndex = IndiceQueSeraSelecionado;
            }
        }

        async void OnSaveClicked(object sender, EventArgs e)
		{
            var lancamentoReceita = (LancamentoReceita)BindingContext;
            lancamentoReceita.MesAno = lancamentoReceita.DataReceita.ToString("MM/yyyy");
            lancamentoReceita.Codigo = listaContaReceita.Items[listaContaReceita.SelectedIndex].Substring(0, 4);
            await App.LancamentoReceitaDB.SaveItemAsync(lancamentoReceita);
			await Navigation.PopAsync();
		}

		async void OnDeleteClicked(object sender, EventArgs e)
		{
            var lancamentoReceita = (LancamentoReceita)BindingContext;
            await App.LancamentoReceitaDB.DeleteItemAsync(lancamentoReceita);
			await Navigation.PopAsync();
		}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

        void OnPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            /**
             * Esse método encontra-se aqui para que você saiba como implementá-lo.
             * Pode remover para produção.
             */
            //situacao.Items[listaContaReceita.SelectedIndex];
        }
    }
}

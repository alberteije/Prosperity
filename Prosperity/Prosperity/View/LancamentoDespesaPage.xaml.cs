using Models;
using System;
using System.Collections;
using Xamarin.Forms;

namespace Prosperity.View
{
	public partial class LancamentoDespesaPage : ContentPage
	{
        public IList ListaContaDespesa;

        public LancamentoDespesaPage()
		{
            InitializeComponent();
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

            var lancamentoDespesa = (LancamentoDespesa)BindingContext;
            if (lancamentoDespesa.Codigo != null)
            {
                var contaDespesa = await App.ContaDespesaDB.GetItemPorCodigoAsync(lancamentoDespesa.Codigo);
                int IndiceQueSeraSelecionado = listaContaDespesa.Items.IndexOf(contaDespesa.CodigoDescricao);
                listaContaDespesa.SelectedIndex = IndiceQueSeraSelecionado;
            }
        }

        async void OnSaveClicked(object sender, EventArgs e)
		{
            try
            {
                var lancamentoDespesa = (LancamentoDespesa)BindingContext;
                lancamentoDespesa.MesAno = lancamentoDespesa.DataDespesa.ToString("MM/yyyy");
                lancamentoDespesa.Codigo = listaContaDespesa.Items[listaContaDespesa.SelectedIndex].Substring(0, 4);
                await App.LancamentoDespesaDB.SaveItemAsync(lancamentoDespesa);
			    await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        async void OnDeleteClicked(object sender, EventArgs e)
		{
            var lancamentoDespesa = (LancamentoDespesa)BindingContext;
            await App.LancamentoDespesaDB.DeleteItemAsync(lancamentoDespesa);
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
            //situacao.Items[listaContaDespesa.SelectedIndex];
        }
    }
}

using Models;
using System;
using Xamarin.Forms;

namespace Prosperity.View
{
	public partial class ContaDespesaPage : ContentPage
	{
		public ContaDespesaPage(bool exclusao)
		{
			InitializeComponent();
            BotaoExcluir.IsVisible = exclusao;
        }

        async void OnSaveClicked(object sender, EventArgs e)
		{
			var contaDespesa = (ContaDespesa)BindingContext;
			await App.ContaDespesaDB.SaveItemAsync(contaDespesa);
			await Navigation.PopAsync();
		}

		async void OnDeleteClicked(object sender, EventArgs e)
		{
			var contaDespesa = (ContaDespesa)BindingContext;
			await App.ContaDespesaDB.DeleteItemAsync(contaDespesa);
			await Navigation.PopAsync();
		}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}

using Models;
using System;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class ContaReceitaPage : ContentPage
	{

		public ContaReceitaPage(bool exclusao)
		{
            InitializeComponent();
            BotaoExcluir.IsVisible = exclusao;
		}

		async void OnSaveClicked(object sender, EventArgs e)
		{
			var contaReceita = (ContaReceita)BindingContext;
			await App.ContaReceitaDB.SaveItemAsync(contaReceita);
			await Navigation.PopAsync();
		}

		async void OnDeleteClicked(object sender, EventArgs e)
		{
			var contaReceita = (ContaReceita)BindingContext;
			await App.ContaReceitaDB.DeleteItemAsync(contaReceita);
			await Navigation.PopAsync();
		}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}

}



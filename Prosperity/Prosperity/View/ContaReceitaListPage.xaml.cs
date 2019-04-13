using Models;
using System;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class ContaReceitaListPage : ContentPage
	{
		public ContaReceitaListPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			listView.ItemsSource = await App.ContaReceitaDB.GetItemsAsync();
		}

		async void OnItemAdded(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ContaReceitaPage(false)
			{
				BindingContext = new ContaReceita()
			});
		}

		async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			await Navigation.PushAsync(new ContaReceitaPage(true)
            {
				BindingContext = e.SelectedItem as ContaReceita
            });
		}
	}
}

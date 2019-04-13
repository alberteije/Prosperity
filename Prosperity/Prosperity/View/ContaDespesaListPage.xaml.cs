using Models;
using System;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class ContaDespesaListPage : ContentPage
	{
		public ContaDespesaListPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			listView.ItemsSource = await App.ContaDespesaDB.GetItemsAsync();
		}

		async void OnItemAdded(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ContaDespesaPage(false)
            {
				BindingContext = new ContaDespesa()
			});
		}

		async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			await Navigation.PushAsync(new ContaDespesaPage(true)
            {
				BindingContext = e.SelectedItem as ContaDespesa
            });
		}
	}
}

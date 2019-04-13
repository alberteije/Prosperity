using EasyFarm.OFX;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.IO;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class ExtratoBancarioFilterPage : ContentPage
	{

        FileHelper fileHelper = new FileHelper();
        public string Filtro;
        public FileData filedata;
        public bool SelecionouOFX;

        public ExtratoBancarioFilterPage()
		{
			InitializeComponent();
            SelecionouOFX = false;
            filedata = null;
            labelSelecaoOFX.Text = "";
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine(mesAnoDatePicker.Date);
        }

        protected override async void OnAppearing()
		{
			base.OnAppearing();
        }

        async void OnFiltrarClicked(object sender, EventArgs e)
        {
            try
            {
                // Configura o filtro
                Filtro = "[MesAno] = '" + mesAnoDatePicker.Date.ToString("MM/yyyy") + "'";

                await Navigation.PushAsync(new ExtratoBancarioListPage
                {
                    filedata = filedata,
                    SelecionouOFX = SelecionouOFX,
                    Filtro = Filtro,
                    MesAno = mesAnoDatePicker.Date.ToString("MM/yyyy")
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        async void OnSelecionaOfx(object sender, EventArgs e)
        {
            try
            {
                filedata = await CrossFilePicker.Current.PickFile();
                labelSelecaoOFX.Text = "Arquivo OFX Selecionado: " + filedata.FileName;
                SelecionouOFX = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message); 
            }
        }
    }
}

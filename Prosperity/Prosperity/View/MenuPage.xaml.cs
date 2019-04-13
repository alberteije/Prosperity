using System.Collections.Generic;
using Xamarin.Forms;

namespace Prosperity.View
{
    public partial class MenuPage : ContentPage
    {
        RootPage root;
        List<HomeMenuItem> menuItems;
        public MenuPage(RootPage root)
        {
            this.root = root;
            InitializeComponent();

            ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem { Title = "Início", MenuType = MenuType.Inicio, Icon ="info.png" },
                    new HomeMenuItem { Title = "Contas de Receita", MenuType = MenuType.ContaReceita, Icon ="sales.png" },
                    new HomeMenuItem { Title = "Contas de Despesa", MenuType = MenuType.ContaDespesa, Icon = "sales.png" },
                    new HomeMenuItem { Title = "Lançamento de Receita", MenuType = MenuType.LancamentoReceita, Icon = "customers.png" },
                    new HomeMenuItem { Title = "Lançamento de Despesa", MenuType = MenuType.LancamentoDespesa, Icon = "customers.png" },
                    new HomeMenuItem { Title = "Extrato Bancário", MenuType = MenuType.ExtratoBancario, Icon = "products.png" },
                    new HomeMenuItem { Title = "Resumo Mensal", MenuType = MenuType.ResumoMensal, Icon = "about.png" },
                    new HomeMenuItem { Title = "Gráficos", MenuType = MenuType.Graficos, Icon = "icon.png" }
                };

            ListViewMenu.SelectedItem = menuItems[0];

            ListViewMenu.ItemSelected += async (sender, e) => 
                {
                    if(ListViewMenu.SelectedItem == null)
                        return;

                    await this.root.NavigateAsync(((HomeMenuItem)e.SelectedItem).MenuType);
                };
        }
    }
}


using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Prosperity.View
{


    public class RootPage : MasterDetailPage
    {
        Dictionary<MenuType, NavigationPage> Pages { get; set; }

        public RootPage()
        {
            Pages = new Dictionary<MenuType, NavigationPage>();
            Master = new MenuPage(this);

            var page = new AppNavigationPage(new IntroPage
            {
                Title = "Início",
                Icon = new FileImageSource { File = "info.png" }
            });
            SetDetailIfNull(page);
            Pages.Add(MenuType.Inicio, page);
        }

        void SetDetailIfNull(Page page)
        {
            if (Detail == null && page != null)
                Detail = page;
        }

        public async Task NavigateAsync(MenuType id)
        {
            try
            {

                Page newPage;
                if (!Pages.ContainsKey(id))
                {
                    switch (id)
                    {
                        case MenuType.Inicio:

                            var page = new AppNavigationPage(new IntroPage
                            {
                                Title = "Início",
                                Icon = new FileImageSource { File = "sales.png" }
                            });
                            SetDetailIfNull(page);
                            Pages.Add(id, page);

                            break;
                        case MenuType.ContaReceita:
                        
                            page = new AppNavigationPage(new ContaReceitaListPage
                                { 
                                    Title = "Contas de Receita", 
                                    Icon = new FileImageSource { File = "sales.png" }
                                });
                            SetDetailIfNull(page);
                            Pages.Add(id, page);
                        
                            break;
                        case MenuType.ContaDespesa:

                            page = new AppNavigationPage(new ContaDespesaListPage
                            {
                                Title = "Contas de Despesa",
                                Icon = new FileImageSource { File = "sales.png" }
                            });
                            SetDetailIfNull(page);
                            Pages.Add(id, page);

                            break;
                        case MenuType.LancamentoReceita:
                        
                            page = new AppNavigationPage(new LancamentoReceitaFilterPage
                            {
                                Title = "Lançamentos de Receita",
                                Icon = new FileImageSource { File = "sales.png" }
                            });
                            SetDetailIfNull(page);
                            Pages.Add(id, page);
                        
                            break;
                        case MenuType.LancamentoDespesa:

                            page = new AppNavigationPage(new LancamentoDespesaFilterPage
                            {
                                Title = "Lançamentos de Despesa",
                                Icon = new FileImageSource { File = "sales.png" }
                            });
                            SetDetailIfNull(page);
                            Pages.Add(id, page);

                            break;
                        case MenuType.ExtratoBancario:

                            page = new AppNavigationPage(new ExtratoBancarioFilterPage
                            {
                                Title = "Extrato Bancário",
                                Icon = new FileImageSource { File = "sales.png" }
                            });
                            SetDetailIfNull(page);
                            Pages.Add(id, page);

                            break;
                        case MenuType.ResumoMensal:

                            page = new AppNavigationPage(new ResumoMensalFilterPage
                            {
                                Title = "Resumo Mensal",
                                Icon = new FileImageSource { File = "sales.png" }
                            });
                            SetDetailIfNull(page);
                            Pages.Add(id, page);

                            break;
                        case MenuType.Graficos:

                            page = new AppNavigationPage(new GraficosFilterPage
                            {
                                Title = "Gráficos",
                                Icon = new FileImageSource { File = "sales.png" }
                            });
                            SetDetailIfNull(page);
                            Pages.Add(id, page);

                            break;
                    }
                }

                newPage = Pages[id];
                if (newPage == null)
                    return;

                //pop to root for Windows Phone
                if (Detail != null && Device.OS == TargetPlatform.WinPhone)
                {
                    await Detail.Navigation.PopToRootAsync();
                }

                Detail = newPage;

                if (Device.Idiom != TargetIdiom.Tablet)
                    IsPresented = false;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }

    public class RootTabPage : TabbedPage
    {
        public RootTabPage()
        {
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            this.Title = this.CurrentPage.Title;
        }
    }

    public class AppNavigationPage :NavigationPage
    {
        public AppNavigationPage(Page root)
            : base(root)
        {
            Init();
        }

        public AppNavigationPage()
        {
            Init();
        }

        void Init()
        {
            BarTextColor = Color.White;
        }
    }

    public enum MenuType
    {
        Inicio,
        ContaReceita,
        ContaDespesa,
        LancamentoReceita,
        LancamentoDespesa,
        ExtratoBancario,
        ResumoMensal,
        Graficos
    }

    public class HomeMenuItem
    {
        public HomeMenuItem()
        {
            MenuType = MenuType.Inicio;
        }

        public string Icon { get; set; }

        public MenuType MenuType { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public int Id { get; set; }
    }

}


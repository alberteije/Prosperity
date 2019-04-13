using Data;
using Prosperity.View;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prosperity
{
    public class App : Application
    {
        static Application app;

        static ContaReceitaDatabase contaReceitaDB;
        static ContaDespesaDatabase contaDespesaDB;
        static LancamentoReceitaDatabase lancamentoReceitaDB;
        static LancamentoDespesaDatabase lancamentoDespesaDB;
        static ExtratoBancoDatabase extratoBancoDB;

        public App()
        {
            app = this;

            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            GoToRoot();
        }

        public static void GoToRoot()
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                app.MainPage = new RootTabPage();
            }
            else
            {
                app.MainPage = new RootPage();
            }
        }

        public static ContaReceitaDatabase ContaReceitaDB
        {
            get
            {
                try
                {
                    if (contaReceitaDB == null)
                    {
                        contaReceitaDB = new ContaReceitaDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("T2TiFinanceiroXF.db3"));
                    }
                    return contaReceitaDB;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Erro = " + e.Message);
                    return null;
                }
            }
        }

        public static ContaDespesaDatabase ContaDespesaDB
        {
            get
            {
                try
                {
                    if (contaDespesaDB == null)
                    {
                        contaDespesaDB = new ContaDespesaDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("T2TiFinanceiroXF.db3"));
                    }
                    return contaDespesaDB;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Erro = " + e.Message);
                    return null;
                }
            }
        }

        public static LancamentoReceitaDatabase LancamentoReceitaDB
        {
            get
            {
                try
                {
                    if (lancamentoReceitaDB == null)
                    {
                        lancamentoReceitaDB = new LancamentoReceitaDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("T2TiFinanceiroXF.db3"));
                    }
                    return lancamentoReceitaDB;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Erro = " + e.Message);
                    return null;
                }
            }
        }

        public static LancamentoDespesaDatabase LancamentoDespesaDB
        {
            get
            {
                try
                {
                    if (lancamentoDespesaDB == null)
                    {
                        lancamentoDespesaDB = new LancamentoDespesaDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("T2TiFinanceiroXF.db3"));
                    }
                    return lancamentoDespesaDB;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Erro = " + e.Message);
                    return null;
                }
            }
        }

        public static ExtratoBancoDatabase ExtratoBancoDB
        {
            get
            {
                try
                {
                    if (extratoBancoDB == null)
                    {
                        extratoBancoDB = new ExtratoBancoDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("T2TiFinanceiroXF.db3"));
                    }
                    return extratoBancoDB;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Erro = " + e.Message);
                    return null;
                }
            }
        }

        public static object Console { get; private set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}

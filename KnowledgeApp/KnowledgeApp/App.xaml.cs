using KnowledgeApp.Services;
using KnowledgeApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KnowledgeApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<DataStoreService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

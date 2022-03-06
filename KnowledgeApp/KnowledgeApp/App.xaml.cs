using KnowledgeApp.Services;
using KnowledgeApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KnowledgeApp
{
    public partial class App : Application
    {

        //public static IDataService DataService { get; set; }

        public App()
        {
            InitializeComponent();

            /*DataService = new AzureDataService();
            MainPage = new NavigationPage(new ItemList());*/
            DependencyService.Register<DataContentAPI>();
            MainPage = new NavigationPage(new DataListView());
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

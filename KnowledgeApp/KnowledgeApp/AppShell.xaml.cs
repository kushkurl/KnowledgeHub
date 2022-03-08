using KnowledgeApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace KnowledgeApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DataListView), typeof(DataListView));
            Routing.RegisterRoute(nameof(DataDetailView), typeof(DataDetailView));
            Routing.RegisterRoute(nameof(DataEdit), typeof(DataEdit));
            Routing.RegisterRoute(nameof(DataNew), typeof(DataNew));
            /*Routing.RegisterRoute(nameof(ItemList), typeof(ItemList));*/
        }
    }
}

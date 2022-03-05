using KnowledgeApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace KnowledgeApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
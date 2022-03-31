using KnowledgeApp.Models;
using KnowledgeApp.ViewModels;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KnowledgeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        //public AsyncCommand<Category> SelectCommand { get; }
        public ObservableCollection<Category> Categories { get; set; }
        DataManagerBase databse;
        public HomeView()
        {
           
            InitializeComponent();
            databse = new DataManagerBase();
            Categories = new ObservableCollection<Category>();
            //SelectCommand = new AsyncCommand<Category>(Selected);
            //LoadItemsCommand = new AsyncCommand(ExecuteLoadItemsCommand);
            ExecuteLoadItemsCommand();
        }
       /* private async Task Selected(Category data)
        {
            var route = $"{nameof(Views.DataListView)}?category={data}";
            await AppShell.Current.GoToAsync(route);
            //throw new NotImplementedException();
        }*/

        private async void ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Categories.Clear();
                var items = await databse.restService.GetCategory();
                if (items == null)
                {
                    items.Add(new Category() { Id = 1, Name = "No category available!" });
                }

                var totalCategories = items.Count;
                //int count = 0;
                for (int rowIndex = 0; rowIndex < totalCategories; rowIndex++)
                {
                    /*for (int columnIndex = 0; columnIndex <= 2; columnIndex++)
                    {
                        DynamicGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });*/
                        var category = items[rowIndex];
                        /*if (count >= items.Count)
                        {
                            break;
                        }*/
                        var item = items[rowIndex];
                        //count += 1;
                        Random random= new Random();
                        var button = new Button
                        {
                            BindingContext = item,
                            Text = item.Name,
                            //Command = new MvvmHelpers.Commands.Command(async () => await AppShell.Current.GoToAsync($"{nameof(Views.DataListView)}?category={item}") ),
                            //HorizontalTextAlignment = TextAlignment.Center,
                            //VerticalTextAlignment = TextAlignment.Center,
                            HeightRequest = 90,
                            WidthRequest = 110,
                            Margin = 5,
                            BackgroundColor = Color.FromRgba(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255), 80),
                            VerticalOptions = LayoutOptions.Fill,
                            HorizontalOptions = LayoutOptions.Fill
                        };
                    button.Command = new MvvmHelpers.Commands.Command(async () =>  await AppShell.Current.GoToAsync($"{nameof(Views.DataListView)}?category={item}"));
                    flexLayout.Children.Add(button);
                    //DynamicGrid.Children.Add(label, columnIndex, rowIndex);
                }
                activityIndicator.IsRunning = false;
                activityIndicator.IsVisible = false;
                //}

                /*foreach (var item in items)
                {
                    Categories.Add(item);
                }*/
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
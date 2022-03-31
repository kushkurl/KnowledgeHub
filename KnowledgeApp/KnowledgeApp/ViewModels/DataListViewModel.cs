using KnowledgeApp.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KnowledgeApp.ViewModels
{
    //[QueryProperty(nameof(category), nameof(category))]
    public class DataListViewModel : DataManagerBase
    {
        private Category category;
        public Category Category
        {
            get { return category; }
            set
            {
                category = value;
                LoadData(value);
            }
        }
        public ObservableRangeCollection<DataContent> Data { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<DataContent> SelectCommand { get; }
        private DataContent selectedData;
        public DataContent SelectedData
        {
            get => selectedData;
            set => SetProperty(ref selectedData, value);
        }
        public DataListViewModel()
        {
            //Title = "Jobs";

            Data = new ObservableRangeCollection<DataContent>();
            LoadData(category);
            RefreshCommand = new AsyncCommand(Refresh);
            SelectCommand = new AsyncCommand<DataContent>(Selected);
            AddCommand = new AsyncCommand(Add);
        }
        async Task Add()
        {
            var route = $"{nameof(Views.DataDetailView)}";
            await AppShell.Current.GoToAsync(route);
        }
        private async Task Selected(DataContent data)
        {
            var route = $"{nameof(Views.DataDetailView)}?cId={data}";
            await AppShell.Current.GoToAsync(route);
            //throw new NotImplementedException();
        }
        public async Task Refresh()
        {
            IsBusy = true;
            Data.Clear();
            LoadData(Category);
            IsBusy = false;
        }
        public async void LoadData(Category category)
        {
            IEnumerable<DataContent> data = await restService.GetData(2);
            Data.AddRange(data);
        }
    }
}
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
    [QueryProperty(nameof(Category), nameof(Category))]
    public class DataListViewModel : DataManagerBase
    {
        private int category;
        public int Category
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
            Data = new ObservableRangeCollection<DataContent>();
            //LoadData(category);
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
            var route = $"{nameof(Views.DataDetailView)}?DataId={data.id}&Categoryid={data.CategoryID}";
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
        public async void LoadData(int category)
        {
            Data.Clear();
            IEnumerable<DataContent> data = await restService.GetData(category);
            Data.AddRange(data);
        }
    }
}
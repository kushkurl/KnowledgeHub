using KnowledgeApp.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeApp.ViewModels
{
    public class DataListViewModel : DataManagerBase
    {
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
            LoadData();
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
            //var route = $"{nameof(Views.JobDetailPage)}?JobId={data.id}";
            //await AppShell.Current.GoToAsync(route);
            throw new NotImplementedException();
        }
        public async Task Refresh()
        {
            IsBusy = true;
            Data.Clear();
            LoadData();
            IsBusy = false;
        }
        public async void LoadData()
        {
            IEnumerable<DataContent> data = await restService.GetData();
            Data.AddRange(data);
        }
    }
}
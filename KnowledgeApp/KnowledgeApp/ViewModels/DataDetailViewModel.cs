using KnowledgeApp.Models;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KnowledgeApp.ViewModels
{
    [QueryProperty(nameof(data), nameof(data))]
    public class DataDetailViewModel : DataManagerBase
    {
        private DataContent data;

        public AsyncCommand SaveCommand { get; }
        public AsyncCommand DeleteCommand { get; }
        public DataContent Data
        {
            get { return data; }
            set
            {
                data = value;
                LoadJob(value);
            }
        }

        public DataDetailViewModel()
        {
            SaveCommand = new AsyncCommand(Save);
            DeleteCommand = new AsyncCommand(Delete);
        }
        async Task Delete()
        {
            DataContent DataObj = new DataContent()
            {
                id = data.id,
                Title = title,
                Description = description,
            };
            if (data != null)
            {
                await restService.Delete(DataObj);
            }

            await Shell.Current.GoToAsync("..");
        }
        async Task Save()
        {
            DataContent DataObj = new DataContent()
            {
                id = data.id,
                Title = title,
                Description = description,
            };
            if (data == null)
            {
                await restService.Add(DataObj);
            }
            else
            {
                await restService.Update(DataObj);
            }

            await Shell.Current.GoToAsync("..");
        }

        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public async void LoadJob(DataContent DataObj)
        {
            var data = await restService.GetData(DataObj); ;
            Title = data.Title;
            Description = data.Description;
        }
    }
}

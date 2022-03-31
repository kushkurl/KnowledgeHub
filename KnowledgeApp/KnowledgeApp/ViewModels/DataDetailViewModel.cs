using KnowledgeApp.Models;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KnowledgeApp.ViewModels
{
    [QueryProperty(nameof(DataId), nameof(DataId))]
    public class DataDetailViewModel : DataManagerBase
    {
        private int dataId;

        public AsyncCommand SaveCommand { get; }
        public AsyncCommand DeleteCommand { get; }
        public int DataId
        {
            get { return dataId; }
            set
            {
                dataId = value;
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
                id = dataId,
                Title = title,
                Description = description,
            };
            if (dataId != 0)
            {
                await restService.Delete(2,DataObj);
            }

            await Shell.Current.GoToAsync("..");
        }
        async Task Save()
        {
            DataContent DataObj = new DataContent()
            {
                id = dataId,
                Title = title,
                Description = description,
            };
            if (dataId == 0)
            {
                await restService.Add(2,DataObj);
            }
            else
            {
                await restService.Update(2,DataObj);
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
        public async void LoadJob(int dataId)
        {
            var content = await restService.GetData(2, dataId); ;
            Title = content.Title;
            Description = content.Description;
        }
    }
}

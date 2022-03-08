using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeApp.ViewModels
{
    public class DataNewViewModel : DataManagerBase
    {
        private int dataId;
        public int DataId
        {
            get { return dataId; }
            set
            {
                dataId = value;
                LoadJob(value);
            }
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
            var data = await restService.GetData(dataId); ;
            Title = data.Title;
            Description = data.Description;
        }
    }
}

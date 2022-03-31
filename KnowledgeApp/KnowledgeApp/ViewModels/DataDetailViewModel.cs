using KnowledgeApp.Models;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KnowledgeApp.ViewModels
{
    [QueryProperty(nameof(DataId), nameof(DataId))]
    [QueryProperty(nameof(Categoryid), nameof(Categoryid))]
    public class DataDetailViewModel : DataManagerBase
    {
        private int dataId;
        private int categoryid;


        private List<Category> categories;
        public List<Category> Categories
        {
            get => categories;
            set => SetProperty(ref categories, value);
        }

        public AsyncCommand SaveCommand { get; }
        public AsyncCommand DeleteCommand { get; }
        public int DataId
        {
            get { return dataId; }
            set
            {
                dataId = value;
                //LoadJob(value);
            }
        }
        public int Categoryid
        {
            get { return categoryid; }
            set
            {
                categoryid = value;
                LoadJob();
            }
        }

        public DataDetailViewModel()
        {
            Categories = new List<Category>();
            
            //SelectedCategory.Id = categoryid;
            //LoadJob(DataId);
            SaveCommand = new AsyncCommand(Save);
            DeleteCommand = new AsyncCommand(Delete);
            ExecuteLoadItemsCommand();
        }

        private async void ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            Categories.Clear();
            Categories = await restService.GetCategory();
            if (Categories == null)
            {
                Categories.Add(new Category() { Id = 0, Name = "No category available!" });
            }                     
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
                await restService.Delete(categoryid, DataObj);
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
                CategoryID = selectedCategory.Id,
                file = "test"
            };
            if (dataId == 0)
            {
                await restService.Add(categoryid, DataObj);
            }
            else
            {
                await restService.Update(categoryid, DataObj);
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
        public async void LoadJob()
        {
            var content = await restService.GetData(categoryid, dataId); ;
            Title = content.Title;
            Description = content.Description;
            SelectedCategory = Categories.Find(x => x.Id == content.CategoryID);
        }

      /*  protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }*/

        private Category selectedCategory;

        public Category SelectedCategory { get => selectedCategory; set => SetProperty(ref selectedCategory, value); }
    }
}

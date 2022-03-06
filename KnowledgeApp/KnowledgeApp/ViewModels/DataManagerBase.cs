using KnowledgeApp.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KnowledgeApp.ViewModels
{
    public class DataManagerBase : BaseViewModel
    {
        public IRestService restService => DependencyService.Get<IRestService>();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace KnowledgeApp
{
    public static class URIConstant
    {
        public static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://kushagrajobmanagerapi.azurewebsites.net/api/data" : "https://kushagrajobmanagerapi.azurewebsites.net/api/data";
    }
}

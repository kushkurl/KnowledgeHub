using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace KnowledgeApp
{
    public static class URIConstant
    {
        public static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "Azure web app url" : "https://localhost:44326/api/data/";
    }
}

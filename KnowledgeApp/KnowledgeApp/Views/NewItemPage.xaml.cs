using KnowledgeApp.Models;
using KnowledgeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KnowledgeApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public DataContent Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}
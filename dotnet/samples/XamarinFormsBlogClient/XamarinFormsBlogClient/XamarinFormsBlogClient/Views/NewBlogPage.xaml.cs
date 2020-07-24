using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinFormsBlogClient.Models;
using XamarinFormsBlogClient.ViewModels;

namespace XamarinFormsBlogClient.Views
{
    public partial class NewBlogPage : ContentPage
    {
        public Item Item { get; set; }

        public NewBlogPage()
        {
            InitializeComponent();
            BindingContext = new NewBlogViewModel();
        }
    }
}
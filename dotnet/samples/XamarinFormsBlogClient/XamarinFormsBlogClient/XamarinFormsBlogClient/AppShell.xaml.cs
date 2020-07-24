using System;
using System.Collections.Generic;
using XamarinFormsBlogClient.ViewModels;
using XamarinFormsBlogClient.Views;
using Xamarin.Forms;

namespace XamarinFormsBlogClient
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewBlogPage), typeof(NewBlogPage));
        }

    }
}

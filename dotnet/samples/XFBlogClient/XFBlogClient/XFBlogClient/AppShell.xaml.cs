using System;
using System.Collections.Generic;
using XFBlogClient.ViewModels;
using XFBlogClient.Views;
using Xamarin.Forms;

namespace XFBlogClient
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BlogDetailPage), typeof(BlogDetailPage));
            Routing.RegisterRoute(nameof(NewBlogPage), typeof(NewBlogPage));
        }

    }
}

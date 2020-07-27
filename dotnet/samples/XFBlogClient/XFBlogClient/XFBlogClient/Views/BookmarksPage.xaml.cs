using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFBlogClient.ViewModels;

namespace XFBlogClient.Views
{
    public partial class BookmarksPage : ContentPage
    {
        public BookmarksPage()
        {
            InitializeComponent();
            BindingContext = new BookmarksViewModel();
        }
    }
}
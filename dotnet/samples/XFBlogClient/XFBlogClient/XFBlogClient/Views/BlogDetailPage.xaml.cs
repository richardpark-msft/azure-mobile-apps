using System.ComponentModel;
using Xamarin.Forms;
using XFBlogClient.ViewModels;

namespace XFBlogClient.Views
{
    public partial class BlogDetailPage : ContentPage
    {
        public BlogDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new BlogDetailViewModel();
        }
    }
}
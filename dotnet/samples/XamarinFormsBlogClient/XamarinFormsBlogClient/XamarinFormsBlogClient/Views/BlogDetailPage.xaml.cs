using System.ComponentModel;
using Xamarin.Forms;
using XamarinFormsBlogClient.ViewModels;

namespace XamarinFormsBlogClient.Views
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
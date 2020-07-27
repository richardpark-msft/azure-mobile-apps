using Xamarin.Forms;
using XamarinFormsBlogClient.Models;
using XamarinFormsBlogClient.ViewModels;

namespace XamarinFormsBlogClient.Views
{
    public partial class NewBlogPage : ContentPage
    {
        public BlogPost Post { get; set; }

        public NewBlogPage()
        {
            InitializeComponent();
            BindingContext = new NewBlogViewModel();
        }
    }
}
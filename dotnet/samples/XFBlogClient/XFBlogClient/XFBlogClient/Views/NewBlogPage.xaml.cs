using Xamarin.Forms;
using XFBlogClient.Models;
using XFBlogClient.ViewModels;

namespace XFBlogClient.Views
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
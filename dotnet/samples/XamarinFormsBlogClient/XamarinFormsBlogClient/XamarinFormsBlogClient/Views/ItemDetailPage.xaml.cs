using System.ComponentModel;
using Xamarin.Forms;
using XamarinFormsBlogClient.ViewModels;

namespace XamarinFormsBlogClient.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
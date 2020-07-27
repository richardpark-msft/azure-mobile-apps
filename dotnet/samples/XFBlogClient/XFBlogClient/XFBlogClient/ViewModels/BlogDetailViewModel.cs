using System;
using System.Diagnostics;
using System.Threading.Tasks;
using XFBlogClient.Models;
using Xamarin.Forms;
using XFBlogClient.Views;

namespace XFBlogClient.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class BlogDetailViewModel : BaseViewModel
    {
        private string _itemId;
        public Command NavigateBackCommand { get; private set; }
        private BlogPost _blogPost;
        public BlogPost BlogPost
        {
            get => _blogPost;
            set => SetProperty(ref _blogPost, value);
        }

        public BlogDetailViewModel()
        {
            NavigateBackCommand = new Command(async () => await OnNavigateBack());
        }

        private async Task OnNavigateBack()
        {
            await Shell.Current.GoToAsync("..", animate:true);
        }

        public string ItemId
        {
            get => _itemId;
            set
            {
                _itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string blogPostId)
        {
            try
            {
                BlogPost = await DataStore.GetItemAsync(blogPostId);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}

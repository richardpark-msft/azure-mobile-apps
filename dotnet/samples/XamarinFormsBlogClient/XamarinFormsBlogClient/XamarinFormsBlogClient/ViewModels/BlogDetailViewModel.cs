using System;
using System.Diagnostics;
using System.Threading.Tasks;
using XamarinFormsBlogClient.Models;
using Xamarin.Forms;

namespace XamarinFormsBlogClient.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class BlogDetailViewModel : BaseViewModel
    {
        private string _itemId;

        private BlogPost _blogPost;
        public BlogPost BlogPost
        {
            get => _blogPost;
            set => SetProperty(ref _blogPost, value);
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

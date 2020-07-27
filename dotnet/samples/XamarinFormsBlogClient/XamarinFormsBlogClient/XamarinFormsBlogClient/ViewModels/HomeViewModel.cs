using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Bogus;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinFormsBlogClient.Models;
using XamarinFormsBlogClient.Services;
using XamarinFormsBlogClient.Views;

namespace XamarinFormsBlogClient.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<BlogPost> BlogPosts { get; set; }


        private string _avatarUrl;
        public string AvatarUrl
        {
            get => _avatarUrl;
            set => SetProperty(ref _avatarUrl, value);
        }

        private BlogPost _selectedBlogPost;
        public BlogPost SelectedBlogPost
        {
            get => _selectedBlogPost;
            set => SetProperty(ref _selectedBlogPost, value);
        }

        public Command ShowBlogPost { get; set; }

        public HomeViewModel()
        {
            ShowBlogPost = new Command(async (post) => await OnShowBlogPost());
            Title = "Home";

            AvatarUrl = new Faker().Internet.Avatar();

            var dataStore = DependencyService.Get<IDataStore<BlogPost>>();

            var blogPosts = dataStore.GetItemsAsync().GetAwaiter().GetResult();
            BlogPosts = new ObservableCollection<BlogPost>(blogPosts);
        }

        private async Task OnShowBlogPost()
        {
            await Shell.Current.GoToAsync($"{nameof(BlogDetailPage)}?{nameof(BlogDetailViewModel.ItemId)}={SelectedBlogPost.Id}");
        }
    }
}
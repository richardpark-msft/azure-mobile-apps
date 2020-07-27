using Bogus;

namespace XFBlogClient.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private string _avatarUrl;
        public string AvatarUrl
        {
            get => _avatarUrl;
            set => SetProperty(ref _avatarUrl, value);
        }

        private string _authorName;
        public string AuthorName
        {
            get => _authorName;
            set => SetProperty(ref _authorName, value);
        }

        public ProfileViewModel()
        {
            Title = "Profile";

            AvatarUrl = new Faker().Internet.Avatar();
            AuthorName = new Faker().Name.FullName();
        }
    }
}
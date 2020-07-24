namespace XamarinFormsBlogClient.Models
{
    public class BlogPost
    {
        public string Title { get; set; }
        public int CommentCount { get; set; }
        public bool ShowComments { get; set; }
        public string Data { get; set; }
        public string ImageUrl { get; set; }
    }
}
using System;
using Azure.Mobile.Server.Entity;

namespace E2EServer.DataObjects
{
    public class BlogPost : EntityTableData
    {
        public string Title { get; set; }
        public int CommentCount { get; set; }
        public bool ShowComments { get; set; }
        public string Data { get; set; }
        public string ImageUrl { get; set; }
        public string AuthorAvatarUrl { get; set; }
        public string AuthorName { get; set; }
        public DateTime PostedAt { get; set; }
        public bool IsBookmarked { get; set; }
    }
}

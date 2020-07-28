using Azure.Mobile.Server.Entity;
using System;

namespace BlogServer.DataObjects
{
    public class PostComment : EntityTableData
    {
        public string PostId { get; set; }
        public string Text { get; set; }
        public string OwnerId { get; set; }
        public DateTimeOffset PostedAt { get; set; }
    }
}

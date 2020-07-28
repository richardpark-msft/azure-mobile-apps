using Azure.Mobile.Server.Entity;

namespace BlogServer.DataObjects
{
    public class Bookmark : EntityTableData
    {
        public string PostId { get; set; }
        public string UserId { get; set; }
    }
}

using Azure.Mobile.Server.Entity;

namespace BlogServer.DataObjects
{
    public class User : EntityTableData
    {
        public string AvatarURL { get; set; }
        public string Username { get; set; }
    }
}

using API.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using API.SenderMethods;

namespace API.Endpoints
{
    public class User : BaseEndpoint
    {
        protected override string MainPoint { get; } = "user";
        private string ReposPoint => GetChildPoint("repos");

        public User(Sender send) : base(send)
        {
        }

        public CurrentUserInfo GetCurrentUserInfo()
            => (CurrentUserInfo)Send.Get<CurrentUserInfo>(MainPoint, HttpStatusCode.OK);

        public FolderInfo CreateFolder(string name, string description = null, bool @private = true)
            => (FolderInfo)Send.Post<FolderInfo>(
                ReposPoint,
                HttpStatusCode.Created,
                new CreateFolder(name, description, @private));

        public List<FolderInfo> GetAllFolders()
            => ((List<FolderInfo>)Send.Get<List<FolderInfo>>(ReposPoint, HttpStatusCode.OK)).ToList();
    }
}
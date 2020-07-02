using System.Net;
using API.SenderMethods;

namespace API.Endpoints
{
    public class Folder : BaseEndpoint
    {
        protected override string MainPoint { get; } = "repos";

        public Folder(Sender send) : base(send)
        {
        }

        public void DeleteCurrentFolder(string userLogin, string folderName) 
            => Send.Delete<string>(GetChildPoint(userLogin, folderName), HttpStatusCode.NoContent);
    }
}
using System.Net;

namespace API.Endpoints
{
    internal class Folder : BaseEndpoint
    {
        protected override string MainPoint { get; } = "repos";

        public Folder(Sender.Sender send) : base(send)
        {
        }

        public void DeleteCurrentFolder(string userLogin, string folderName)
            => Send.Delete<string>(GetChildPoint(userLogin, folderName), HttpStatusCode.NoContent);
    }
}
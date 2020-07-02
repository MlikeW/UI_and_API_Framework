using System.IO;
using API.SenderMethods;

namespace API.Endpoints
{
    public abstract class BaseEndpoint
    {
        protected abstract string MainPoint { get; }

        private string GetSingleChildPoint(string childPoint) => Path.Combine(MainPoint, childPoint);//todo: ?

        protected string GetChildPoint(params string[] childPoint) => GetSingleChildPoint(Path.Combine(childPoint));

        protected Sender Send;

        protected BaseEndpoint(Sender send) => Send = send;
    }
}
using System.ComponentModel;

namespace API.SenderMethods
{
    public enum ContentTypes
    {
        [Description("application/json")]
        Json,
        [Description("application/octet-stream")]
        Bytes,
        [Description("text/plain; charset=UTF-8")]
        Text
        //todo: MultipartFormData
    }
}
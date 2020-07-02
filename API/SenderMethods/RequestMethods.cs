using CommonUtilities.Methods;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;

namespace API.SenderMethods
{
    public static class RequestMethods
    {
        private static readonly string Token = ConfigurationManager.AppSettings["SourceToken"];
        private static readonly string UserAgent = ConfigurationManager.AppSettings["UserAgent"];

        internal static void AddHeaders(this HttpWebRequest request, Dictionary<HttpRequestHeader, string> headers)
            => headers?.Keys.ToList().ForEach(key => request.AddHeader(key, headers[key]));

        internal static byte[] ToBytesByContentType(this object body,
            HttpWebRequest request, ContentTypes type)
            => type switch
            {
                ContentTypes.Bytes => (byte[]) body,
                { } => body.ToStringByContentType(request, type).ToBytes()
            };

        internal static void ApplyStandardHeaders(this HttpWebRequest request, ContentTypes acceptedContentType)
        {
            request.UserAgent = UserAgent;
            request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token}");
            request.Accept = acceptedContentType.GetEnumSinglePropertyValue<DescriptionAttribute>();
        }

        internal static object ConvertResponse<T>(this string responseString, ContentTypes acceptedType)
            => acceptedType switch
            {
                ContentTypes.Json => responseString.TryConvertToJContainer<T>(),
                ContentTypes.Bytes => responseString.ToBytes(),
                _ => responseString
            };

        private static void AddHeader(this WebRequest request, HttpRequestHeader header, string value)
            => request?.Headers.Add(header, value);

        private static string ToStringByContentType(this object body, WebRequest request, ContentTypes type)
        {
            var content = type switch
            {
                ContentTypes.Json => JToken.FromObject(body).ToString(),
                ContentTypes.Text => (string) body,
                _ => default
            };
            request.ApplyContentHeaders(type, content);
            return content;
        }

        private static void ApplyContentHeaders(this WebRequest request, ContentTypes contentType, string content)
        {
            request.ContentType = contentType.GetEnumSinglePropertyValue<DescriptionAttribute>();
            request.ContentLength = content.Length;
        }
    }
}
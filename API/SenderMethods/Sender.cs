﻿using CommonUtilities.Methods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;

namespace API.SenderMethods
{
    public class Sender
    {
        private enum RequestType
        {
            GET,
            POST,
            DELETE
        }

        private static readonly string Url = ConfigurationManager.AppSettings["SourceUrl"];

        public object Get<T>(
            string requestEndpoint,
            HttpStatusCode expectedStatusCode,
            object body = null,
            ContentTypes contentType = ContentTypes.Json,
            Dictionary<HttpRequestHeader, string> headers = null,
            ContentTypes acceptedContentType = ContentTypes.Json)
            => SendRequest<T>(RequestType.GET, requestEndpoint, expectedStatusCode, body, contentType, headers, acceptedContentType);

        public object Post<T>(
            string requestEndpoint,
            HttpStatusCode expectedStatusCode,
            object body = null,
            ContentTypes contentType = ContentTypes.Json,
            Dictionary<HttpRequestHeader, string> headers = null,
            ContentTypes acceptedContentType = ContentTypes.Json)
            => SendRequest<T>(RequestType.POST, requestEndpoint, expectedStatusCode, body, contentType, headers, acceptedContentType);

        public object Delete<T>(
            string requestEndpoint,
            HttpStatusCode expectedStatusCode,
            object body = null,
            ContentTypes contentType = ContentTypes.Json,
            Dictionary<HttpRequestHeader, string> headers = null,
            ContentTypes acceptedContentType = ContentTypes.Json)
            => SendRequest<T>(RequestType.DELETE, requestEndpoint, expectedStatusCode, body, contentType, headers, acceptedContentType);

        private static object SendRequest<T>(
            RequestType requestType,
            string requestEndpoint,
            HttpStatusCode expectedStatusCode,
            object body = null,
            ContentTypes contentType = ContentTypes.Json,
            Dictionary<HttpRequestHeader, string> headers = null,
            ContentTypes acceptedContentType = ContentTypes.Json)
        {
            var endpointFinalUrl = $"{Url}{requestEndpoint}".AddParametersToUrl(body);
            var request = (HttpWebRequest)WebRequest.Create(endpointFinalUrl);

            request.ApplyStandardHeaders(acceptedContentType);
            request.AddHeaders(headers);
            request.Method = requestType.ToString();

            if (body != null)//todo: avoid partial parameters to url(ignoring during convertation)
            {
                var content = body.ToBytesByContentType(request, contentType);
                using var stream = request.GetRequestStream();
                stream.Write(content, 0, content.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            if(!expectedStatusCode.Equals(response.StatusCode))
            {
                throw new Exception("Received incorrect status code.");
            }

            var responseString = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()).ReadToEnd();//check why not to string
            Console.WriteLine($"---Send {request.Method} to {endpointFinalUrl}: \n{responseString}");

            return responseString.ConvertResponse<T>(acceptedContentType);
        }
    }
}
using Newtonsoft.Json.Linq;
using System.Text;

namespace CommonUtilities.Methods
{
    public static class ConverterMethods
    {
        public static object TryConvertToJContainer<T>(this string responseString)
        {
            try
            {
                return JToken.Parse(responseString).ToObject<T>();
            }
            catch
            {
                return responseString;
            }
        }

        public static byte[] ToBytes(this string bodyString) => Encoding.UTF8.GetBytes(bodyString);

    }
}

using System.Net.Http;
using System.Net.Http.Headers;

namespace Golf.Global.Implementations
{
    public static class HttpClientExtensionMethods
    {
        public static HttpClient Clear(this HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public static HttpClient Clear(this HttpClient httpClient, string mediaType)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));

            return httpClient;
        }
    }
}

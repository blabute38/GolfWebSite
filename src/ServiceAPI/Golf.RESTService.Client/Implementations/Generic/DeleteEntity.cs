using Golf.Global.Implementations;
using Golf.RESTService.Client.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Golf.RESTService.Client.Implementations.Generic
{
    public class DeleteEntity : IDeleteEntity, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public DeleteEntity(HttpClient httpClient, string baseUrl)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }

            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task DeleteEntityAsync(int id)
        {
            var url = new UrlEncoder(_baseUrl)
               .AddPath(id);

            var response = await _httpClient.Clear().DeleteAsync(url.ToString());

            if (response.IsSuccessStatusCode)
            {
                return;
            }

            //return default(T);
        }
    }
}

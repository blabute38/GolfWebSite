using Golf.RESTService.Client.Implementations.Generic;
using System.Net.Http;

namespace Golf.RESTService.Client.Implementations.Golfers
{
    public class DeleteGolfer : DeleteEntity
    {
        private static readonly string baseUrl = "http://threesacrowd-restservice.gear.host/api/golfers";

        public DeleteGolfer(HttpClient httpClient)
            : base(httpClient, baseUrl)
        {
        }
    }
}

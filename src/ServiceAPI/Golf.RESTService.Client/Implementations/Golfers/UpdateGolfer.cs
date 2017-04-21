using Golf.RESTService.Client.Implementations.Generic;
using Golf.ServiceLayer.Dto.Implementations;
using System.Net.Http;

namespace Golf.RESTService.Client.Implementations.Golfers
{
    public class UpdateGolfer<T> : UpdateEntity<T> where T: GolferDto
    {
        private static readonly string baseUrl = "http://threesacrowd-restservice.gear.host/api/golfers";

        public UpdateGolfer(HttpClient httpClient)
            : base(httpClient, baseUrl)
        {
        }
    }
}

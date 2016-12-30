using Golf.RESTService.Client.Implementations.Generic;
using Golf.RESTService.Client.Interfaces;
using Golf.ServiceLayer.Dto.Implementations;
using System.Net.Http;

namespace Golf.RESTService.Client.Implementations.Golfers
{
    public class RetrieveGolfer<T> : RetrieveEntity<T> where T: GolferDto
    {
        private static readonly string baseUrl = "http://threesacrowd-restservice.gear.host/api/golfers";

        public RetrieveGolfer(HttpClient httpClient)
            : base(httpClient, baseUrl, null)
        {
        }

    }
}

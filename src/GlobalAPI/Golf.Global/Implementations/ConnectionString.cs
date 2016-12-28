using Golf.Global.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Golf.Global.Implementations
{
    public class ConnectionString : IConnectionString
    {
        IConfigurationRoot _configuration;

        public ConnectionString(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public string connectionString
        {
            get { return _configuration["ConnectionStrings:defaultConnectionString"]; }
        }
    }
}

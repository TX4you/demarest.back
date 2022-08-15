using dema.back.Repositories.Interface;
using Microsoft.Extensions.Configuration;

namespace dema.back.Repositories
{
    public class Help : IHelp
    {
        IConfiguration _configuration;
        public Help(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("AppSettings").GetSection("ConnectionStrings").Value;
            return connection;
        }
    }
}
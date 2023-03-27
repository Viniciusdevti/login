using Microsoft.Extensions.Configuration;

namespace Login.Application.Helpers
{
    public class Keys
    {
        public readonly string _keyToken;
        public readonly string _keyPassword;
        public Keys(IConfiguration configuration)
        {
            _keyToken = configuration["keyToken"] ?? String.Empty;
            _keyPassword = configuration["keyPassword"] ?? String.Empty;
        }

    }
}

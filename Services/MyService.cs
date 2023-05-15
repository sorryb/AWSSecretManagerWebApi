using Microsoft.Extensions.Options;

namespace TestSecretManagerWebApi.Services
{
    public class MyService
    {
        private readonly MyApiCredentials _myApiCredentials;

        public MyService(IOptions<MyApiCredentials> options)
        {
            _myApiCredentials = options.Value;
        }

        public MyApiCredentials GetSecrets()
        {
            return _myApiCredentials;
        }
    }
}

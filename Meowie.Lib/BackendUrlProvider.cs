namespace Meowie.Lib
{
    public class BackendUrlProvider : IBackendUrlProvider
    {
        private readonly string _url;

        private BackendUrlProvider()
        {
            
        }
        public BackendUrlProvider(string url)
        {
            _url = url;
        }

        public Uri GetBackEndUri()
        {
            return new Uri(_url);
        }

        public string GetBackEndUrl()
        {
            return _url;
        }

    }
}

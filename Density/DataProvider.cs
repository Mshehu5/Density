using System.Threading.Tasks;

namespace Density
{
    public abstract class DataProvider
    {

        #region Properties

        protected IClientBuilder ClientBuilder { get; private set; }
        protected IRequestBuilder RequestBuilder { get; private set; }

        #endregion

        #region Constructor

        public DataProvider(IClientBuilder clientBuilder, IRequestBuilder requestBuilder)
        {
            ClientBuilder = clientBuilder;
            RequestBuilder = requestBuilder;
        }

        #endregion

        #region Public Methods

        public T Get<T>(Endpoint endpoint)
        {
            IDataResponse response = GetRaw(endpoint);
            return ParseResponse<T>(response);
        }
        public async Task<T> GetAsync<T>(Endpoint endpoint)
        {
            IDataResponse response = await GetRawAsync(endpoint);
            return ParseResponse<T>(response);
        }
        public IDataResponse GetRaw(Endpoint endpoint) => ExecuteEndpoint(endpoint);
        public async Task<IDataResponse> GetRawAsync(Endpoint endpoint) => await Task.Run(() => GetRaw(endpoint));

        #endregion

        #region Protected Methods

        protected abstract T ParseResponse<T>(IDataResponse response);
        protected virtual IDataResponse ExecuteEndpoint(Endpoint endpoint)
        {
            using (IDataClient client = ClientBuilder.Build(endpoint))
                using (IDataRequest request = RequestBuilder.Build(endpoint))
                    return client.Execute(request);
        }

        #endregion

    }
}

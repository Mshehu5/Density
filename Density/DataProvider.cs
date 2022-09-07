using System.Threading.Tasks;

namespace Density
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DataProvider
    {

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        protected IClientBuilder ClientBuilder { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        protected IRequestBuilder RequestBuilder { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientBuilder"></param>
        /// <param name="requestBuilder"></param>
        public DataProvider(IClientBuilder clientBuilder, IRequestBuilder requestBuilder)
        {
            ClientBuilder = clientBuilder;
            RequestBuilder = requestBuilder;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public T Get<T>(Endpoint endpoint)
        {
            IDataResponse response = GetRaw(endpoint);
            return ParseResponse<T>(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(Endpoint endpoint)
        {
            IDataResponse response = await GetRawAsync(endpoint);
            return ParseResponse<T>(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public IDataResponse GetRaw(Endpoint endpoint) => ExecuteEndpoint(endpoint);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public async Task<IDataResponse> GetRawAsync(Endpoint endpoint) => await Task.Run(() => GetRaw(endpoint));

        #endregion

        #region Protected Methods

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        protected abstract T ParseResponse<T>(IDataResponse response);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        protected virtual IDataResponse ExecuteEndpoint(Endpoint endpoint)
        {
            using (IDataClient client = ClientBuilder.Build(endpoint))
                using (IDataRequest request = RequestBuilder.Build(endpoint))
                    return client.Execute(request);
        }

        #endregion

    }
}

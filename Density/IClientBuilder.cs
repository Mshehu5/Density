using System;

namespace Density
{
    /// <summary>
    /// 
    /// </summary>
    public interface IClientBuilder : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        IDataClient Build(Endpoint endpoint);
    }
}

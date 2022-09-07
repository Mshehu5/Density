using System;

namespace Density
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRequestBuilder : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        IDataRequest Build(Endpoint endpoint);
    }
}

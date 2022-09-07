using System;

namespace Density
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataClient : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IDataResponse Execute(IDataRequest request);
    }
}

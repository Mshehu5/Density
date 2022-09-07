using System;

namespace Density
{
    public interface IDataClient : IDisposable
    {
        IDataResponse Execute(IDataRequest request);
    }
}

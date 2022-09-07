using System;

namespace Density
{
    public interface IRequestBuilder : IDisposable
    {
        IDataRequest Build(Endpoint endpoint);
    }
}

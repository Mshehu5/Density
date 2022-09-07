using System;

namespace Density
{
    public interface IClientBuilder : IDisposable
    {
        IDataClient Build(Endpoint endpoint);
    }
}

using System.Net;

namespace Density
{
    public interface IDataResponse
    {
        HttpStatusCode Status { get; set; }
        string Content { get; set; }
    }
}

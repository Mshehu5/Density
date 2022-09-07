using System.Net;

namespace Density
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataResponse
    {
        /// <summary>
        /// 
        /// </summary>
        HttpStatusCode Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Content { get; set; }
    }
}

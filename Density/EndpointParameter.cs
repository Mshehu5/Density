namespace Density
{
    /// <summary>
    /// 
    /// </summary>
    public class EndpointParameter
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public EndpointParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}

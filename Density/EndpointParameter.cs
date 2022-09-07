namespace Density
{
    public class EndpointParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public EndpointParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}

using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Filter
{
    public class TypeFilterBuilder : IFilterBuilder
    {
        private readonly string _type;

        public TypeFilterBuilder(string type)
        {
            _type = type;
        }

        public object ToJsonObject()
        {
            return new JObject(new JProperty("type", new JObject(new JProperty("value", _type))));
        }
    }
}
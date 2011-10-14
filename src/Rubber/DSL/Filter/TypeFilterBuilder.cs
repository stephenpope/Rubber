using Newtonsoft.Json.Linq;

namespace Rubber.DSL.Filter
{
    public class TypeFilterBuilder : IFilterBuilder
    {
        private readonly string _type;

        public TypeFilterBuilder(string type)
        {
            _type = type;
        }

        #region IFilterBuilder Members

        public object ToJsonObject()
        {
            return new JObject(new JProperty("type", new JObject(new JProperty("value", _type))));
        }

        #endregion
    }
}
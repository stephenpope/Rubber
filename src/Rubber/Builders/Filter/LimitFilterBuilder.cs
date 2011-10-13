using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Filter
{
    public class LimitFilterBuilder : IFilterBuilder
    {
        private readonly int _limit;

        public LimitFilterBuilder(int limit)
        {
            _limit = limit;
        }

        public object ToJsonObject()
        {
            return new JObject(new JProperty("limit", new JObject(new JProperty("value", _limit))));
        }
    }
}
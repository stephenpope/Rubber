using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Filter
{
    public class MatchAllFilterBuilder : IFilterBuilder
    {
        public object ToJsonObject()
        {
            return new JObject(new JProperty("match_all", new JObject()));
        }
    }
}
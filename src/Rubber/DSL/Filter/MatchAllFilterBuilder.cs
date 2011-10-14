using Newtonsoft.Json.Linq;

namespace Rubber.DSL.Filter
{
    public class MatchAllFilterBuilder : IFilterBuilder
    {
        #region IFilterBuilder Members

        public object ToJsonObject()
        {
            return new JObject(new JProperty("match_all", new JObject()));
        }

        #endregion
    }
}
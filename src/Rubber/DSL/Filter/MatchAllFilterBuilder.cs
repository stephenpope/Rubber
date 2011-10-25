using Newtonsoft.Json.Linq;

namespace Rubber.DSL.Filter
{
    public class MatchAllFilterBuilder : IFilterBuilder
    {
        private const string NAME = NameRegistry.MatchAllFilterBuilder;

        #region IFilterBuilder Members

        public object ToJsonObject()
        {
            return new JObject(new JProperty(NAME, new JObject()));
        }

        #endregion
    }
}
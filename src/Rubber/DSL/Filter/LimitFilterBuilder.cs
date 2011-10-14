using Newtonsoft.Json.Linq;

namespace Rubber.DSL.Filter
{
    public class LimitFilterBuilder : IFilterBuilder
    {
        private readonly int _limit;

        public LimitFilterBuilder(int limit)
        {
            _limit = limit;
        }

        #region IFilterBuilder Members

        public object ToJsonObject()
        {
            return new JObject(new JProperty("limit", new JObject(new JProperty("value", _limit))));
        }

        #endregion
    }
}
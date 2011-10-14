using Newtonsoft.Json.Linq;

namespace Rubber.DSL.Filter
{
    public class NotFilterBuilder : IFilterBuilder
    {
        private readonly IFilterBuilder _filter;
        private bool _cache;
        private string _filterName;

        public NotFilterBuilder(IFilterBuilder filter)
        {
            _filter = filter;
        }

        public NotFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public NotFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        #region IFilterBuilder Members

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("not", new JObject()));

            content["not"]["filter"] = _filter.ToJsonObject() as JObject;

            if (_filterName != null)
            {
                content["not"]["_name"] = _filterName;
            }

            if (_cache)
            {
                content["not"]["_cache"] = _cache;
            }

            return content;
        }

        #endregion
    }
}
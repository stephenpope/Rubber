using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Filter
{
    public class NotFilterBuilder : IFilterBuilder
    {
        private IFilterBuilder _filter;
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


        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("not", new JObject()));

            ((JObject)content.SelectToken("not")).Add(new JProperty("filter", _filter.ToJsonObject()));

            if (_filterName != null)
            {
                ((JObject)content.SelectToken("not")).Add(new JProperty("_name", _filterName));
            }

            if (_cache)
            {
                ((JObject)content.SelectToken("not")).Add(new JProperty("_cache", _cache));
            }

            return content;
        }
    }
}
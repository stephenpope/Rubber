using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Filter
{
    public class AndFilterBuilder : IFilterBuilder
    {
        private readonly List<IFilterBuilder> _filters = new List<IFilterBuilder>();
        private bool _cache;
        private string _cacheKey;
        private string _filterName;

        public AndFilterBuilder(IEnumerable<IFilterBuilder> filters)
        {
            _filters.AddRange(filters);
        }

        public AndFilterBuilder(params IFilterBuilder[] filters)
        {
            _filters.AddRange(filters);
        }

        public AndFilterBuilder Add(IFilterBuilder filterBuilder)
        {
            _filters.Add(filterBuilder);
            return this;
        }

        public AndFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public AndFilterBuilder CacheKey(string cacheKey)
        {
            _cacheKey = cacheKey;
            return this;
        }

        public AndFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("and", new JObject()));
            
            ((JObject)content.SelectToken("and")).Add(new JProperty("filters",new JArray(_filters.Select(t=>t.ToJsonObject()))));

            if (_filterName != null)
            {
                ((JObject)content.SelectToken("and")).Add(new JProperty("_name", _filterName));
            }

            if (_cache)
            {
                ((JObject)content.SelectToken("and")).Add(new JProperty("_cache", _cache));
            }

            if (_cacheKey != null)
            {
                ((JObject)content.SelectToken("and")).Add(new JProperty("_cache_key", _cacheKey));
            }

            return content;
        }
    }
}
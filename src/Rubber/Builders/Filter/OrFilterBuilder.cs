using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Rubber.Builders.Filter
{
    public class OrFilterBuilder : IFilterBuilder
    {
        private List<IFilterBuilder> _filters = new List<IFilterBuilder>();
        private bool _cache;
        private string _cacheKey;
        private string _filterName;

        public OrFilterBuilder(params IFilterBuilder[] filters)
        {
            _filters.AddRange(filters);
        }

        /// <summary>
        /// Adds a filter to the list of filters to "or".
        /// </summary>
        /// <param name="filterBuilder"></param>
        /// <returns></returns>
        public OrFilterBuilder Add(IFilterBuilder filterBuilder)
        {
            _filters.Add(filterBuilder);
            return this;
        }

        public OrFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        /// <summary>
        /// Should the filter be cached or not. Defaults to false.
        /// </summary>
        /// <param name="cache"></param>
        /// <returns></returns>
        public OrFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public OrFilterBuilder CacheKey(string cacheKey)
        {
            _cacheKey = cacheKey;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("or",new JObject()));

            ((JObject)content.SelectToken("or")).Add(new JProperty("filters", new JArray(_filters.Select(t => t.ToJsonObject()))));

            if (_filterName != null)
            {
                ((JObject)content.SelectToken("or")).Add(new JProperty("_name", _filterName));
            }

            if (_cache)
            {
                ((JObject)content.SelectToken("or")).Add(new JProperty("_cache", _cache));
            }

            if (_cacheKey != null)
            {
                ((JObject)content.SelectToken("or")).Add(new JProperty("_cache_key", _cacheKey));
            }

            return content;
        }
    }
}
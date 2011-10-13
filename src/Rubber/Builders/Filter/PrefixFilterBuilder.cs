using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Filter
{
    public class PrefixFilterBuilder : IFilterBuilder
    {
        private string _filterName;
        private bool _cache;
        private string _cacheKey;
        private readonly string _name;
        private readonly string _prefix;

        public PrefixFilterBuilder(string name, string prefix)
        {
            _name = name;
            _prefix = prefix;
        }

        public PrefixFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        public PrefixFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public PrefixFilterBuilder CacheKey(string cacheKey)
        {
            _cacheKey = cacheKey;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("prefix", new JObject(new JProperty(_name, _prefix))));

            if (_filterName != null)
            {
                ((JObject)content.SelectToken("prefix")).Add(new JProperty("_name", _filterName));
            }

            if (_cache)
            {
                ((JObject)content.SelectToken("prefix")).Add(new JProperty("_cache", _cache));
            }

            if (_cacheKey != null)
            {
                ((JObject)content.SelectToken("prefix")).Add(new JProperty("_cache_key", _cacheKey));
            }

            return content;
        }
    }
}
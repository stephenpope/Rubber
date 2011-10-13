
using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Filter
{
    public class TermFilterBuilder : IFilterBuilder
    {
        private string _name;
        private object _value;
        private bool _cache;
        private string _cacheKey;
        private string _filterName;

        public TermFilterBuilder(string name, string value) : this(name, (object)value) { }

        public TermFilterBuilder(string name, int value) : this(name, (object)value) { }

        public TermFilterBuilder(string name, long value) : this(name, (object)value) { }

        public TermFilterBuilder(string name, float value) : this(name, (object)value) { }

        public TermFilterBuilder(string name, double value) : this(name, (object)value) { }

        public TermFilterBuilder(string name, object value)
        {
            _name = name;
            _value = value;
        }

        public TermFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        public TermFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public TermFilterBuilder CacheKey(string cacheKey)
        {
            _cacheKey = cacheKey;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("term", new JObject(new JProperty(_name, _value))));

            if(_filterName != null)
            {
                ((JObject)content.SelectToken("term")).Add(new JProperty("_name",_filterName));
            }

            if (_cache)
            {
                ((JObject)content.SelectToken("term")).Add(new JProperty("_cache", _cache));
            }

            if (_cacheKey != null)
            {
                ((JObject)content.SelectToken("term")).Add(new JProperty("_cache_key", _cacheKey));
            }

            return content;
        }

    }
}
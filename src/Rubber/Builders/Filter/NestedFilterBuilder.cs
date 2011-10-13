using Newtonsoft.Json.Linq;
using Rubber.Builders.Query;

namespace Rubber.Builders.Filter
{
    public class NestedFilterBuilder : IFilterBuilder
    {
        private IQueryBuilder _queryBuilder;
        private IFilterBuilder _filterBuilder;

        private string _path;

        private string _scope;

        private bool _cache;
        private string _cacheKey;
        private string _filterName;


        public NestedFilterBuilder(string path, IQueryBuilder queryBuilder)
        {
            _path = path;
            _queryBuilder = queryBuilder;
            _filterBuilder = null;
        }

        public NestedFilterBuilder(string path, IFilterBuilder filterBuilder)
        {
            _path = path;
            _queryBuilder = null;
            _filterBuilder = filterBuilder;
        }

        public NestedFilterBuilder Scope(string scope)
        {
            _scope = scope;
            return this;
        }

        public NestedFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        public NestedFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public NestedFilterBuilder CacheKey(string cacheKey)
        {
            _cacheKey = cacheKey;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("nested",new JObject()));

            if(_queryBuilder != null)
            {
                ((JObject)content.SelectToken("nested")).Add(new JProperty("query", _queryBuilder.ToJsonObject()));
            }
            else
            {
                ((JObject)content.SelectToken("nested")).Add(new JProperty("filter", _filterBuilder.ToJsonObject()));
            }

            ((JObject)content.SelectToken("nested")).Add(new JProperty("path", _path));

            if (_scope != null)
            {
                ((JObject)content.SelectToken("nested")).Add(new JProperty("_scope", _scope));
            }

            if (_filterName != null)
            {
                ((JObject)content.SelectToken("nested")).Add(new JProperty("_name", _filterName));
            }

            if (_cache)
            {
                ((JObject)content.SelectToken("nested")).Add(new JProperty("_cache", _cache));
            }

            if (_cacheKey != null)
            {
                ((JObject)content.SelectToken("nested")).Add(new JProperty("_cache_key", _cacheKey));
            }

            return content;
        }
    }
}
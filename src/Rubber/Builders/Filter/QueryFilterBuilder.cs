using Newtonsoft.Json.Linq;
using Rubber.Builders.Query;

namespace Rubber.Builders.Filter
{
    public class QueryFilterBuilder : IFilterBuilder
    {
        private readonly IQueryBuilder _queryBuilder;
        private bool _cache;
        private string _filterName;

        public QueryFilterBuilder(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }

        public QueryFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        public QueryFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public object ToJsonObject()
        {
            JObject content; 

            if (_filterName == null && _cache == false)
            {
                content = new JObject(new JProperty("query", _queryBuilder.ToJsonObject()));
            }
            else
            {
                content = new JObject(new JProperty("fquery",new JObject(new JProperty("query",_queryBuilder.ToJsonObject()))));

                if (_filterName != null)
                {
                    ((JObject)content.SelectToken("fquery")).Add(new JProperty("_name", _filterName));
                }

                if (_cache)
                {
                    ((JObject)content.SelectToken("fquery")).Add(new JProperty("_cache", _cache));
                }
            }

            return content;
        }
    }
}
using Newtonsoft.Json.Linq;
using Rubber.DSL.Query;

namespace Rubber.DSL.Filter
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

        #region IFilterBuilder Members

        public object ToJsonObject()
        {
            var content = new JObject();

            if (_filterName == null && _cache == false)
            {
                content["query"] = _queryBuilder.ToJsonObject() as JObject;
            }
            else
            {
                content["fquery"] = new JObject();
                content["fquery"]["query"] = _queryBuilder.ToJsonObject() as JObject;

                if (_filterName != null)
                {
                    content["fquery"]["_name"] = _filterName;
                }

                if (_cache)
                {
                    content["fquery"]["_cache"] = _cache;
                }
            }

            return content;
        }

        #endregion
    }
}
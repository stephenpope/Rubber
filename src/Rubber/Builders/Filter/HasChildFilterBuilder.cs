using Newtonsoft.Json.Linq;
using Rubber.Builders.Query;

namespace Rubber.Builders.Filter
{
    public class HasChildFilterBuilder : IFilterBuilder
    {
        private readonly IQueryBuilder _queryBuilder;
        private readonly string _childType;
        private string _scope;
        private string _filterName;

        public HasChildFilterBuilder(string type, IQueryBuilder queryBuilder)
        {
            _childType = type;
            _queryBuilder = queryBuilder;
        }

        public HasChildFilterBuilder Scope(string scope)
        {
            _scope = scope;
            return this;
        }

        /// <summary>
        /// Sets the filter name for the filter that can be used when searching for matched_filters per hit.
        /// </summary>
        /// <param name="filterName"></param>
        /// <returns></returns>
        public HasChildFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("has_child"),new JObject(new JProperty("query", _queryBuilder.ToJsonObject())));

            ((JObject)content.SelectToken("has_child")).Add(new JProperty("type", _childType)); 

            if(_scope != null)
            {
                ((JObject)content.SelectToken("has_child")).Add(new JProperty("_scope", _scope));    
            }

            if(_filterName != null)
            {
                ((JObject)content.SelectToken("has_child")).Add(new JProperty("_name", _filterName));
            }

            return content;
        }
    }
}
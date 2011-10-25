﻿using System;
using Newtonsoft.Json.Linq;
using Rubber.DSL.Filter;

namespace Rubber.DSL.Query
{
    public class FilteredQueryBuilder : IQueryBuilder
    {
        private readonly IQueryBuilder _queryBuilder;
        private readonly IFilterBuilder _filterBuilder;
        private float? _boost;

        /// <summary>
        /// A query that applies a filter to the results of another query.
        /// </summary>
        /// <param name="queryBuilder">The query to apply the filter to</param>
        /// <param name="filterBuilder">The filter to apply on the query</param>
        public FilteredQueryBuilder(IQueryBuilder queryBuilder, IFilterBuilder filterBuilder)
        {
            _queryBuilder = queryBuilder;
            _filterBuilder = filterBuilder;
        }

        /// <summary>
        /// Sets the boost for this query.  Documents matching this query will (in addition to the normal
        /// weightings) have their score multiplied by the boost provided.
        /// </summary>
        /// <param name="boost"></param>
        /// <returns></returns>
        public FilteredQueryBuilder Boost(float boost)
        {
            _boost = boost;
            return this;
        }

        #region IQueryBuilder Members

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("filtered",new JObject()));
            
            content["filtered"]["query"] = _queryBuilder.ToJsonObject() as JObject;

            content["filtered"]["filter"] = _filterBuilder.ToJsonObject() as JObject;
            
            if(_boost != null)
            {
                content["boost"] = _boost;
            }
            
            return content;
        }

        #endregion
    }
}
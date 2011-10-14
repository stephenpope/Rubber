using System;
using Rubber.DSL.Filter;

namespace Rubber.DSL.Query
{
    public class FilteredQueryBuilder : IQueryBuilder
    {
        public FilteredQueryBuilder(IQueryBuilder queryBuilder, IFilterBuilder filterBuilder)
        {
            throw new NotImplementedException();
        }

        #region IQueryBuilder Members

        public object ToJsonObject()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
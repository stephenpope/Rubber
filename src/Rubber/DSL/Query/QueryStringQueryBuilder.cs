using System;

namespace Rubber.DSL.Query
{
    public class QueryStringQueryBuilder : IQueryBuilder
    {
        public QueryStringQueryBuilder(string queryString)
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
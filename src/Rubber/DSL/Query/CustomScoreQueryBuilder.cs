using System;

namespace Rubber.DSL.Query
{
    public class CustomScoreQueryBuilder : IQueryBuilder
    {
        public CustomScoreQueryBuilder(IQueryBuilder queryBuilder)
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
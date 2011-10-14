using System;

namespace Rubber.DSL.Query
{
    public class CustomBoostFactorQueryBuilder : IQueryBuilder
    {
        public CustomBoostFactorQueryBuilder(IQueryBuilder queryBuilder)
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
using System;

namespace Rubber.DSL.Query
{
    public class MoreLikeThisQueryBuilder : IQueryBuilder
    {
        public MoreLikeThisQueryBuilder(params string[] fields)
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
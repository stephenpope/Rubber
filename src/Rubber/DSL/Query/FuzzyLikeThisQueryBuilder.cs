using System;

namespace Rubber.DSL.Query
{
    public class FuzzyLikeThisQueryBuilder : IQueryBuilder
    {
        public FuzzyLikeThisQueryBuilder(params string[] fields)
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
using System;

namespace Rubber.DSL.Query
{
    public class FuzzyLikeThisFieldQueryBuilder : IQueryBuilder
    {
        public FuzzyLikeThisFieldQueryBuilder(string name)
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
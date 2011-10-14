using System;

namespace Rubber.DSL.Query
{
    public class FuzzyQueryBuilder : IQueryBuilder
    {
        public FuzzyQueryBuilder(string name, string value)
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
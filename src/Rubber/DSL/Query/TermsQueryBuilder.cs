using System;

namespace Rubber.DSL.Query
{
    public class TermsQueryBuilder : IQueryBuilder
    {
        public TermsQueryBuilder(string name, params object[] values)
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
using System;

namespace Rubber.DSL.Query
{
    public class WildcardQueryBuilder : IQueryBuilder
    {
        public WildcardQueryBuilder(string name, string query)
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
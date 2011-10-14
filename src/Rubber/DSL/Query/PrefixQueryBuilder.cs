using System;

namespace Rubber.DSL.Query
{
    public class PrefixQueryBuilder : IQueryBuilder
    {
        public PrefixQueryBuilder(string name, string prefix)
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
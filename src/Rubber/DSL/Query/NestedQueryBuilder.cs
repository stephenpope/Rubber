using System;

namespace Rubber.DSL.Query
{
    public class NestedQueryBuilder : IQueryBuilder
    {
        public NestedQueryBuilder(string path, IQueryBuilder query)
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
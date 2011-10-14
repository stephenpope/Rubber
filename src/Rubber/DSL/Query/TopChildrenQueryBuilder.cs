using System;

namespace Rubber.DSL.Query
{
    public class TopChildrenQueryBuilder : IQueryBuilder
    {
        public TopChildrenQueryBuilder(string type, IQueryBuilder query)
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
using System;

namespace Rubber.DSL.Query
{
    public class IdsQueryBuilder : IQueryBuilder
    {
        public IdsQueryBuilder(params string[] types)
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
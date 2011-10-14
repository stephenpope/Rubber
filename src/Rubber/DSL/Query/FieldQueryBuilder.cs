using System;

namespace Rubber.DSL.Query
{
    public class FieldQueryBuilder : IQueryBuilder
    {
        public FieldQueryBuilder(string name, object query)
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
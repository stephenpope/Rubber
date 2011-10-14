using System;

namespace Rubber.DSL.Query
{
    public class FieldMaskingSpanQueryBuilder : IQueryBuilder
    {
        public FieldMaskingSpanQueryBuilder(ISpanQueryBuilder query, string field)
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
using System;

namespace Rubber.DSL.Query
{
    public class SpanTermQueryBuilder : IQueryBuilder
    {
        public SpanTermQueryBuilder(string name, object value)
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